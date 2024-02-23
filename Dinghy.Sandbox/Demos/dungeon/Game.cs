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
    public static EventBus EventBus = new();
    public static Player Player = new ();
    public static Grid g = new (new (
        new(Engine.Width / 2f, Engine.Height / 2f), 
        new(0.5f, 0.5f), 
        200, 450, 
        new(0.5f, 0.5f), 
        4,
        1));

    public static List<DeckCard> DiscardStack = new ();
    public static Deck Deck = new ();
    public static Track Track = new (4);
    public override void Create()
    {
        Deck.Init();
        // //grid debug
        // for (int i = 0; i < g.Points.Count; i++)
        // {
        //     g.ApplyPositionToEntity(i,new Shape(Palettes.ONE_BIT_MONITOR_GLOW[1],1,1));
        // }

        //ASSUME 4 TRACK SLOTS
        Deck.Draw(4);
        Track.UpdategGameCardState();
        Systems.Init();
    }

    private ImVec2 buttonSize = new () { x = 100, y = 20 };
    public static bool Death = false;
    public override void Update(double dt)
    {
        ImGUIWindow("game",ImGuiWindowFlags_.ImGuiWindowFlags_NoTitleBar, () =>
        {
            if (Death)
            {
                Text($"player died");
                return;
            }
            Text($"HP: {Player.Health}/{Player.MaxHealth}");
            Text($"Hunger:{Player.Hunger}");

            if (!Track.Cards.All(x => x.IsObstacle))
            {
                Button($"Move", buttonSize, () =>
                {
                    Events.Commands.Execute?.Invoke(new PlayerMove());
                    //DONE shouldnt be able to move if all track cards are obstacles
                    //DONE moving heals
                    //DONE moving increases hunger
                    //moving gets an attack of opportuninty if "trapped"
                    //DONE move cycles a card from track (if possible)
                    //DONE move draws if able
                });
            }
            else
            {
                Text($"cant move, all are obstacles");
            }
                
            Button($"Wait", buttonSize, () =>
            {
                Events.Commands.Execute?.Invoke(new PlayerWait());
                //DONE waiting increases hunger
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
            foreach (var e in Track.Cards.OrderBy(x => x.TrackPosition.Value))
            {
                Text($"{e.TrackPosition}:{e.Name}");
            }
            Text("off track cards");
            foreach (var e in DiscardStack)
            {
                Text($"{e.Name}");
            }
            Text("deck cards");
            foreach (var e in Deck.Cards.Where(x => x.DeckPosition.HasValue).OrderBy(x => x.DeckPosition.Value))
            {
                Text($"{e.DeckPosition}:{e.Name}");
            }
            
            
        });
    }
}