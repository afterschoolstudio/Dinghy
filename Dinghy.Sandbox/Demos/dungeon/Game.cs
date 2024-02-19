using System.Linq;
using Depot.Generated.dungeon;
using Dinghy.Core;
using Dinghy.Internal.Sokol;
using static Dinghy.Sandbox.Demos.dungeon.DataTypes;
using static Dinghy.Core.ImGUI.ImGUIHelper.Wrappers;

namespace Dinghy.Sandbox.Demos.dungeon;

[DemoScene("dungeon")]
public class Dungeon : Scene
{
    Player player = new ();
    Grid g = new (new (new(Engine.Width / 2f, Engine.Height / 2f), new(0.5f, 0.5f), 50, 50, new(0.5f, 0.5f), 10, 10));

    private List<DeckCard> Deck = new ();
    private List<DeckCard> GameCards = new ();
    private List<DeckCard> TrackCards = new ();
    private List<DeckCard> OffTrackCards = new ();
    public override void Create()
    {
        foreach (var i in Depot.Generated.dungeon.cards.Lines)
        {
            int iterations = 0;
            if (i.ID == "enemy")
            {
                iterations = 6;
            }
            
            if(i.ID == "big enemy")
            {
                iterations = 2;
            }

            if (i.ID == "floor")
            {
                iterations = 15;
            }

            for (int j = 0; j < iterations; j++)
            {
                var card = new DeckCard(i.ID + $"{j}", i, 4);
                card.OnDestroy += OnDestroyCard;
                Deck.Add(card);
                GameCards.Add(card);
            }
        }

        Deck = Deck.OrderBy(x => Quick.RandFloat()).ToList();
        for (int i = 0; i < Deck.Count; i++)
        {
           Deck[i].SetDeckPosition(i);
           Deck[i].SetTrackPosition(null);
        }
        
        //grab the first four off the top
        for (int i = 0; i < 4; i++)
        {
            var draw = Deck[0];
            draw.SetTrackPosition(i);
            draw.SetDeckPosition(null);
            TrackCards.Add(draw);
            Deck.RemoveAt(0);
        }

        UpdateGameCardState();
        player.PlayerTookAction += OnPlayerAction;
        Systems.Init();
    }

    void DrawNewTrackCard(int? trackPosOverride = null)
    {
        if (Deck.Any())
        {
            var draw = Deck[0];
            draw.SetTrackPosition(trackPosOverride ?? 3);
            draw.SetDeckPosition(null);
            TrackCards.Add(draw);
            Deck.RemoveAt(0);
        }
        
        UpdateGameCardState();
    }

    void PopCardOffTrack(bool drawNew = true)
    {
        var tc = TrackCards.FirstOrDefault(x => x.TrackPosition == 0);
        if (tc != null && tc.Data.canCycleOffBoard)
        {
            TrackCards.Remove(tc);
            tc.SetTrackPosition(null);
            OffTrackCards.Add(tc);
            
            //move everyone left
            foreach (var dc in TrackCards)
            {
                if (dc.TrackPosition > 0)
                {
                    dc.SetTrackPosition(dc.TrackPosition-1);
                }
            }
            
            if (drawNew)
            {
                DrawNewTrackCard();
            }
        }

        UpdateGameCardState();
    }

    void OnDestroyCard(DeckCard d)
    {
        Deck.Remove(d);
        GameCards.Remove(d);
        TrackCards.Remove(d);
        if (d.TrackPosition.HasValue)
        {
            //move everyone left
            foreach (var tc in TrackCards)
            {
                if (tc.TrackPosition > d.TrackPosition)
                {
                    tc.SetTrackPosition(tc.TrackPosition-1);
                }
            }
            DrawNewTrackCard();
        }
        UpdateGameCardState();
    }

    void UpdateGameCardState()
    {
        foreach (var trackCard in GameCards.Where(x => x.TrackPosition.HasValue))
        {
            g.ApplyPositionToEntity(trackCard.TrackPosition.Value,trackCard.Entity);
        }

    }

    private ImVec2 buttonSize = new () { x = 100, y = 20 };
    public override void Update(double dt)
    {
        ImGUIWindow("game",ImGuiWindowFlags_.ImGuiWindowFlags_NoTitleBar, () =>
        {
            bool acted = false;
            Text($"Player HP:{player.Health} XP:{player.XP}");
            
            Button($"Move", buttonSize, () =>
            {
                player.MovePlayer();
            });
            Button($"Wait", buttonSize, () =>
            {
                player.MovePlayer();
            });
            
            
            Text("track cards");
            foreach (var e in TrackCards.OrderBy(x => x.TrackPosition.Value))
            {
                Text($"{e.TrackPosition}:{e.Name}");
            }
            Text("off track cards");
            foreach (var e in OffTrackCards)
            {
                Text($"{e.Name}");
            }
            Text("deck cards");
            foreach (var e in Deck.Where(x => x.DeckPosition.HasValue).OrderBy(x => x.DeckPosition.Value))
            {
                Text($"{e.DeckPosition}:{e.Name}");
            }
            
            
        });

        // if (acted)
        // {
        //     foreach (var e in Enemies.Where(x => x.Aggro && !x.Dead && x.Distance == 0))
        //     {
        //         player.Health -= e.Attack;
        //     }
        //     
        //     foreach (var e in Enemies.Where(x => x.Aggro && !x.Dead && x.Distance > 0))
        //     { 
        //         e.Distance--;
        //     }
        //
        //     if (Quick.RandFloat() > 0.7f)
        //     {
        //         var candidate = Enemies.Where(x => !x.Aggro && !x.Dead).FirstOrDefault();
        //         if (candidate != null)
        //         {
        //             candidate.Aggro = true;
        //         }
        //     }
        // }
    }

    void OnPlayerAction(Player.PlayerAction a)
    {
        switch (a)
        {
            case Player.Move move:
                PopCardOffTrack();
                break;
            case Player.Wait wait:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(a));
        }
    }

    public override void Cleanup()
    {
        player.PlayerTookAction -= OnPlayerAction;
    }
}