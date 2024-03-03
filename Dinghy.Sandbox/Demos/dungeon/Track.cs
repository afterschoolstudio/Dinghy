using System.Collections;
using System.Numerics;
using Arch.Core.Extensions;
using Dinghy.Core;

namespace Dinghy.Sandbox.Demos.dungeon;

public class Track
{
    public readonly record struct TrackComponent(int cardID);
    public int MaxTrackCards => Dungeon.TrackSize;
    public Dictionary<int,DeckCard?> Cards = new();
    public Grid Grid;

    public void Init()
    {
        Grid = new (new (
        new(Engine.Width / 2f, Engine.Height / 2f), 
        new(0.5f, 0.5f), 
        200, 450, 
        new(0.5f, 0.5f), 
        Dungeon.TrackSize,
        1));

        Cards.Clear();
        
        for (int i = 0; i < MaxTrackCards; i++)
        {
           Cards.Add(i,null); 
        }
    }

    private List<DeckCard> lastUpdatedTrackCards = new();
    public void MoveTrackCardsToLatestTrackPositions(bool applyPositionsDirectly = false)
    {
        var updated = new List<DeckCard>();
        float timeOffset = 0f;
        foreach (var trackCard in Cards.Where(x => x.Value != null))
        {
            if (applyPositionsDirectly)
            {
                Grid.ApplyPositionToEntity(trackCard.Key,trackCard.Value!.Entity);
            }
            else
            {
                if (!lastUpdatedTrackCards.Contains(trackCard.Value))
                {
                    trackCard.Value!.Entity.X = Engine.Width + 200;
                }
                trackCard.Value!.Entity.Y = Grid.Points[trackCard.Key].Y;
                // trackCard.Value!.Entity.X = Engine.Width + 100;
                Coroutines.Start(movePosition(trackCard.Value!,trackCard.Value!.Entity.X,Grid.Points[trackCard.Key].X,timeOffset));
                timeOffset += 0.2f;
            }
            updated.Add(trackCard.Value);
        }

        lastUpdatedTrackCards = new List<DeckCard>(updated);
    }
    
    IEnumerator movePosition(DeckCard c, float startX, float endX, float timeOffset)
    {
        TimeSince off = 0;
        var trans = new Transition<float>(startX, endX, Easing.Option.EaseOutElastic);
        while (off < timeOffset)
        {
            yield return null;
        }
        TimeSince ts = 0;
        while (ts < 0.5f)
        {
            c.Entity.X = startX + ((endX - startX) * (float)trans.Sample(ts / 0.5f));
            yield return null;
        }
        yield return null;
    }

    IEnumerator attackPlayer(DeckCard c, float startY, float endY)
    {
        var trans = new Transition<float>(startY, endY, Easing.Option.EaseOutElastic);
        TimeSince ts = 0;
        while (ts < 0.2f)
        {
            c.Entity.Y = startY + ((endY - startY) * (float)trans.Sample(ts / 0.2f));
            yield return null;
        }
        Dungeon.Player.TakeDamageFromTrackCard(c);
        ts = 0;
        trans = new Transition<float>(startY, endY, Easing.Option.EaseOutExpo);
        while (ts < 0.12f)
        {
            c.Entity.Y = endY + ((startY - endY) * (float)trans.Sample(ts / 0.12f));
            yield return null;
        }
        yield return null;
    }

    public void RemoveTrackCard(int trackIndex) => RemoveTrackCard(Cards[trackIndex]);
    public void RemoveTrackCard(DeckCard card)
    {
        var index = Cards.First(x => x.Value == card).Key;
        Cards[index].Entity.ECSEntity.Remove<TrackComponent>();
        Cards[index].Entity.Active = false;
        Cards[index] = null;
    }

    public void FillEmptyTrackCardSpaces()
    {
        for (int i = 0; i < Cards.Count; i++)
        {
            if (Cards[i] == null)
            {
                fillInTrackForEmptyPos(i);
            }
        }

        void fillInTrackForEmptyPos(int empty)
        {
            //move everyone left
            for (int i = empty + 1; i < Cards.Count; i++)
            {
                Cards[i-1] = Cards[i];
                Cards[i] = null;
            }
        }
    }

    public void Act(Action onComplete = null)
    {
        Coroutines.Start(TrackAct(),onComplete);
    }
    IEnumerator TrackAct()
    {
        int i = 0;
        bool spawnedLogic = false;
        while (i < MaxTrackCards)
        {
            if (Cards[i] != null && Cards[i].Attack > 0 && !spawnedLogic)
            {
                //maybe do some highlight?
                spawnedLogic = true;
                
                Depot.Generated.dungeon.logicTriggers.attacking.Emit(new LogicEvents.LogicData(cardID:Cards[i].ID),(success) =>
                {
                    if(success)
                    {
                        Console.WriteLine($"{Cards[i].ID} damaging player for {Cards[i].Attack}");
                        Coroutines.Start(attackPlayer(Cards[i],Cards[i].Entity.Y,Cards[i].Entity.Y + 80),() => {
                            i++;
                            spawnedLogic = false;
                        });
                    }
                    else
                    {
                        i++;
                        spawnedLogic = false;
                    }
                });
            }
            else
            {
                i++;
                spawnedLogic = false;
            }
            yield return null;
        }
    }

    public void DamageTrackCards(List<DeckCard> cards, Action onComplete = null)
    {
        var c = cards.First(); //NOTE: assuming one for now
        Depot.Generated.dungeon.logicTriggers.attackedByPlayer.Emit(new LogicEvents.LogicData(cardID:c.ID),(success) =>
        {
            if (success)
            {
                c.Health -= 1;
                Coroutines.Start(Shake(c, defaultShake),() =>
                {
                    if (c.Health <= 0)
                    {
                        Console.WriteLine("destroying");
                        // LogicEvents.Emit(new LogicEvents.LogicData(cardID:c.ID),Depot.Generated.dungeon.logicTriggers.destroyed,(success) =>
                        Depot.Generated.dungeon.logicTriggers.destroyed.Emit(new LogicEvents.LogicData(cardID:c.ID),(success) =>
                        {
                            if (success)
                            {
                                Console.WriteLine("destroy callback");
                                c.Entity.ECSEntity.Remove<TrackComponent>();
                                Cards[Cards.First(x => x.Value == c).Key] = null;
                                c.Entity.Active = false;
                                Dungeon.Graveyard.Add(c);

                                //note right now this assumes one death
                                //should instead do this after multiple deaths processed
                                Dungeon.Track.Act(() => {
                                    FillEmptyTrackCardSpaces();
                                    Dungeon.Deck.Draw();
                                    onComplete?.Invoke();
                                });
                            }
                            else
                            {
                                onComplete?.Invoke();
                            }
                        });
                    }
                    else
                    {
                        Dungeon.Track.Act(() => {
                            onComplete?.Invoke();
                        });
                    }
                });
            }
            else
            {
                onComplete?.Invoke();   
            }
        });

        
    }

    private ShakeParams defaultShake = new ShakeParams();
    IEnumerator Shake(DeckCard c, ShakeParams p)
    {
        c.Entity.ColliderActive = false;
        Vector2 start = new Vector2(c.Entity.X, c.Entity.Y);
        TimeSince t = 0;
        TimeSince shakeTimer = 0;
        while (t < p.DeathTime)
        {
            if (shakeTimer >= p.Tick)
            {
                var next = start + Quick.RandUnitCircle() * p.BaseShake * p.Multiplier;
                c.Entity.X = next.X;
                c.Entity.Y = next.Y;
                shakeTimer = 0f;
            }
            
            p.BaseShake -= p.Decay * (float)Engine.DeltaTime;
            p.BaseShake = MathF.Max( p.BaseShake, 0 );
            yield return null;
        }
        c.Entity.X = start.X;
        c.Entity.Y = start.Y;
        c.Entity.ColliderActive = true;
    }
    
    public struct ShakeParams()
    {
        public float Multiplier = 1f;
        public float BaseShake = 12f;
        public float Tick = 0.001f;
        public float Decay = 190f;
        public float DeathTime = 0.1f;
    }
}