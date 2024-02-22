using System.Linq;
using System.Numerics;
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
    Grid g = new (new (
        new(Engine.Width / 2f, Engine.Height / 2f), 
        new(0.5f, 0.5f), 
        200, 450, 
        new(0.5f, 0.5f), 
        4,
        1));

    private List<DeckCard> Deck = new ();
    private List<DeckCard> GameCards = new ();
    private List<DeckCard> TrackCards = new ();
    private List<DeckCard> OffTrackCards = new ();
    public override void Create()
    {
        foreach (var i in Depot.Generated.dungeon.cards.Lines)
        {
            int iterations = i.ID switch
            {
                "enemy" => 6,
                "big enemy" => 2,
                "rock" => 8,
                "floor" => 15,
                _ => 0
            };
            for (int j = 0; j < iterations; j++)
            {
                var card = new DeckCard(i.ID + $"{j}", i, 4);
                card.OnDestroy += OnDestroyCard;
                Deck.Add(card);
                GameCards.Add(card);
            }
        }

        {
            //grid debug
            for (int i = 0; i < g.Points.Count; i++)
            {
                g.ApplyPositionToEntity(i,new Shape(Palettes.ONE_BIT_MONITOR_GLOW[1],1,1));
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
            draw.SetDistance(3);
            TrackCards.Add(draw);
            Deck.RemoveAt(0);
        }
        
        UpdateGameCardState();
    }

    void PopCardOffTrack(bool drawNew = true)
    {
        var tc = TrackCards.FirstOrDefault(x => x.TrackPosition == 0);
        if (tc != null && tc.CanCycleOffBOard)
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
        
        player.GrantXP(d.XPValue);
    }

    void UpdateGameCardState()
    {
        foreach (var trackCard in GameCards.Where(x => x.TrackPosition.HasValue))
        {
            g.ApplyPositionToEntity(trackCard.TrackPosition.Value,trackCard.Entity);
        }

    }

    private ImVec2 buttonSize = new () { x = 100, y = 20 };
    private bool death = false;
    public override void Update(double dt)
    {
        ImGUIWindow("game",ImGuiWindowFlags_.ImGuiWindowFlags_NoTitleBar, () =>
        {
            if (death)
            {
                Text($"player died");
                return;
            }
            Text($"{player.Health}/{player.MaxHealth}");
            Text($"Hunger:{player.Hunger}");

            if (!TrackCards.All(x => x.IsObstacle))
            {
                Button($"Move", buttonSize, () =>
                {
                    //DONE shouldnt be able to move if all track cards are obstacles
                    //DONE moving heals
                    //DONE moving increases hunger
                    //moving gets an attack of opportuninty if "trapped"
                    //DONE move cycles a card from track (if possible)
                    //DONE move draws if able
                    player.Move();
                });
            }
            else
            {
                Text($"cant move, all are obstacles");
            }
                
            Button($"Wait", buttonSize, () =>
            {
                //DONE waiting increases hunger
                player.Wait();
                //DONE enemies move close
                //DONE enemies that can attack attack
                //cooldowns,buffs,debuffs progress, etc.
            });
            
            //attacking attacks targeted things (if targetable)
            //attack can change based on weapons (weapons have durability)
            //attacked things will drop stuff
            
            //dropped things may go into inventory or can be picked up immediately
            //picking up counts as an action
            
            
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
    }

    void OnPlayerAction(Player.PlayerAction a)
    {
        switch (a.ActionType)
        {
            case "Move":
                TrackCardsAct();
                PopCardOffTrack();
                break;
            case "Wait":
                TrackCardsAct(moveCloser:true);
                break;
            case "Death":
                death = true; 
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(a));
        }
    }

    void TrackCardsAct(bool moveCloser = false)
    {
        foreach (var tc in TrackCards)
        {
            //try to attack if in range
            if (tc.Distance <= 1)
            {
                player.AttackPlayer(tc.Attack);
            }
            else
            {
                tc.Distance -= 1;
            }
        }
    }

    public override void Cleanup()
    {
        player.PlayerTookAction -= OnPlayerAction;
    }
}