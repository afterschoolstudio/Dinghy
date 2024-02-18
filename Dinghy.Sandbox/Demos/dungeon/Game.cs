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
                Deck.Add(new DeckCard(i.ID+$"{j}",i,4));
                // g.ApplyPositionToEntity(i*2,enemy.Entity);
            }
        }

        Deck.OrderBy(x => Quick.RandFloat());
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
            Deck.RemoveAt(0);
        }
        Systems.Init();
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
                acted = true;
            });
            Button($"Wait", buttonSize, () =>
            {
                acted = true;
            });
            
            
            Text("track cards");
            foreach (var e in Deck.Where(x => x.TrackPosition.HasValue).OrderBy(x => x.TrackPosition.Value))
            {
                Text($"{e.TrackPosition}:{e.Name}");
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
}