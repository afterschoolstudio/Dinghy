using System.Collections;

namespace Dinghy.Sandbox.Demos.dungeon;

public class Player
{
    public int MaxHealth { get; set; } = 10;
    public int Health { get; set; } = 10;
    public int Fullness { get; set; } = 10;
    public int XP { get; private set; } = 0;
    public int MovedDistance { get; private set; } = 0;
    public bool Dead { get; protected set; }

    public void Init()
    {
        Health = MaxHealth;
        Fullness = 10;
        XP = 0;
        MovedDistance = 0;
        Dead = false;
    }
    public void GrantXP(int xp)
    {
        XP += xp;
        if (XP % 5 == 0)
        {
            Health = MaxHealth;
        }
    }

    public void Kill()
    {
        Dead = true;
    }

    public void Move(Action onComplete = null)
    {
        new LogicEvents.Move().Emit((success) =>
        {
            if(!success){onComplete?.Invoke();return;}
            int moveDist = 1; //saturate this with status/buffs/etc
            foreach (var c in Dungeon.Track.Cards.Where(x => x.Value != null))
            {
                c.Value!.Distance += moveDist;
            }
            
            MovedDistance += moveDist;
            // Health = Health + 1 < MaxHealth ? Health + 1 : Health; moving this to keyword
            Fullness--;
            if (Fullness <= 0)
            {
                Dungeon.Player.Kill();
                onComplete?.Invoke();
            }
            else
            {
                //cycle cards
                new LogicEvents.Discard(Dungeon.Track.Cards[0].ID).Emit((success) =>
                {
                    if(!success){onComplete?.Invoke();return;}
                    Dungeon.DiscardStack.Add(Dungeon.Track.Cards[0]);
                    Dungeon.Track.RemoveTrackCard(Dungeon.Track.Cards[0]);
                    Dungeon.Track.FillEmptyTrackCardSpaces();
                    Dungeon.Deck.Draw();
                    onComplete?.Invoke();
                });
            }
        });
    }

    public void Wait(Action onComplete = null)
    {
        new LogicEvents.Wait().Emit((success) =>
        {
            if(!success){onComplete?.Invoke();return;}
            Fullness--;
            if (Fullness <= 0)
            {
                Dungeon.Player.Kill();
                onComplete?.Invoke();
            }
            else
            {
                Dungeon.Track.Act(() => {
                    onComplete?.Invoke();
                });
            }
        });
    }

    public void TakeDamageFromTrackCard(DeckCard c)
    {
        if(Dungeon.ActiveDebugOptions.Invincible){return;}
        Health -= c.Attack;
        if (Health <= 0)
        {
            Dungeon.Player.Kill();
        }
    }
}