using System.Linq;
using System.Numerics;
using Depot.Generated.dungeon;
using Dinghy.Core;
using Dinghy.Internal.Sokol;
using static Dinghy.Core.ImGUI.ImGUIHelper.Wrappers;

namespace Dinghy.Sandbox.Demos.dungeon;

[DemoScene("dungeon")]
public class Dungeon : Scene
{
    public static DA_STACK DA_STACK = new();
    public static EventBus EventBus = new();
    public static Player Player = new ();
    

    public static List<DeckCard> DiscardStack = new ();
    public static List<DeckCard> Graveyard = new ();
    public static Deck Deck = new ();
    public static Track Track = new ();
    public static Inventory Inventory = new ();
    public List<DeckCard> GetAllCards()
    {
        var l = new List<DeckCard>();
        l.AddRange(DiscardStack);
        l.AddRange(Graveyard);
        l.AddRange(Deck.Cards);
        l.AddRange(Track.Cards);
        return l;
    }
    public override void Create()
    {
        Init();
        Systems.Init();
    }

    public void Init()
    {
        Player.Init();
        
        foreach (var c in GetAllCards())
        {
            c.DestroyCardEntity();
        }
        DiscardStack.Clear();
        Graveyard.Clear();
        
        Deck.Init();
        Track.Init(4);
        Inventory.Init();
        Deck.Draw(4);
    }

    private ImVec2 buttonSize = new () { x = 100, y = 20 };

    public static DebugOptions ActiveDebugOptions = new();
    public override void Update(double dt)
    {
        MainMenu(() => {
            Menu("Dungeon", () => {
                Checkbox("Don't Damage Enemies", ref ActiveDebugOptions.DontDamageEnemies);
                Checkbox("Player Invincible", ref ActiveDebugOptions.Invincible);
                Button($"Reset", buttonSize, Init);
            });
        });

        Window("game",ImGuiWindowFlags_.ImGuiWindowFlags_NoTitleBar, () =>
        {
            if (Player.Dead)
            {
                Text($"player died");
                Button($"Reset", buttonSize, Init);
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
            foreach (var e in Deck.Cards.OrderBy(x => x.DeckPosition.Value))
            {
                Text($"{e.DeckPosition}:{e.Name}");
            }
        });
        // Quick.DrawEditGUIForObject("shake params",ref Shake);
    }

    // public static ShakeParams Shake = new();
    // public class ShakeParams
    // {
    //     public float Multiplier = 1f;
    //     public float BaseShake = 1f;
    //     public float Tick = 0.001f;
    //     public float Decay = 0.1f;
    //     public float DeathTime = 1f;
    // }

    public class DebugOptions
    {
        public bool DontDamageEnemies;
        public bool Invincible;
    }
}