using System.Collections;
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
    public static EventBus EventBus = new();
    public static Player Player = new ();
    public static int LogicStackID = 0;
    

    public static List<DeckCard> DiscardStack = new ();
    public static List<DeckCard> Graveyard = new ();
    public static int TrackSize = 5;
    public static Deck Deck = new ();
    public static Track Track = new ();
    public static Inventory Inventory = new ();
    public static Equipment Equipment = new ();
    public static Effects Effects = new Effects();

    public override void Create()
    {
        Keywords.InitBindings();
        Logic.InitBindings();
        Systems.Init();
        Init();
    }

    public void Init()
    {
        Player.Init();
        
        foreach (var c in AllCards)
        {
            c.Value.DestroyCardEntity();
        }
        AllCards.Clear();
        
        DiscardStack.Clear();
        Graveyard.Clear();
        
        Deck.Init();
        Track.Init();
        Inventory.Init();
        Equipment.Init();
        
        Logic.MetaEvents.DrawingMultipleCards.Emit(Systems.Logic.RootEvent, postExecution: e =>
        {
            for (int i = 0; i < TrackSize; i++)
            {
                Depot.Generated.dungeon.logicTriggers.draw.Emit(e);
            }
        }, onComplete: () =>
        {
            Console.WriteLine("init draw complete");
            Coroutines.Start(Track.MoveTrackCardsToLatestTrackPositions(),"initial track card movement");
        });
    }

    public enum CardLocation
    {
        NOTFOUND,
        Track,
        Discard,
        Deck,
        Graveyard,
        Inventory,
        Equipment
    }

    public static IEnumerator MoveCard(DeckCard c, CardLocation destination, int? targetPosition = null)
    {
        //NOTE: TODO: this isn't complete and is meant more as the way to globally handle transitions between card states
        var currentLocation =
            DiscardStack.Contains(c) ? CardLocation.Discard :
            Graveyard.Contains(c) ? CardLocation.Graveyard :
            Deck.Cards.Contains(c) ? CardLocation.Deck :
            Track.Cards.Values.Contains(c) ? CardLocation.Track :
            Equipment.Cards.Values.Contains(c) ? CardLocation.Equipment :
            Inventory.Cards.Values.Contains(c) ? CardLocation.Inventory : CardLocation.NOTFOUND;
        if (currentLocation == CardLocation.NOTFOUND)
        {
            Console.WriteLine("CARD NOT FOUND: " + c.ID);
        }
        
        //TODO: validate destination target before moving and return if invalid
        
        switch (currentLocation)
        {
            //TODO: some way of notifying if we need to update card positions in track?
            //or we can literally just do it in here?
            case CardLocation.Track:
                Track.RemoveTrackCard(c);
                break;
            case CardLocation.Discard:
                DiscardStack.Remove(c);
                break;
            case CardLocation.Deck:
                Deck.Cards.Remove(c);
                break;
            case CardLocation.Graveyard:
                Graveyard.Remove(c);
                break;
            case CardLocation.Inventory:
                Inventory.Cards.Remove(Inventory.Cards.First(x => x.Value == c).Key);
                break;
            case CardLocation.Equipment:
                Equipment.Cards.Remove(Equipment.Cards.First(x => x.Value == c).Key);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination), destination, null);
        }
        
        //do fancy transition from current location to new location
        //TODO: card add logic for desitnations here
        switch (destination)
        {
            case CardLocation.Track:
                break;
            case CardLocation.Discard:
                break;
            case CardLocation.Deck:
                break;
            case CardLocation.Graveyard:
                break;
            case CardLocation.Inventory:
                break;
            case CardLocation.Equipment:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination), destination, null);
        }

        yield return null;
    }

    public static void NextDungeonRoom()
    {
        Console.WriteLine("next dungeon room");
        //fetch all valid cards for destructions
        List<DeckCard> destroyCards = new();
        destroyCards.AddRange(DiscardStack);
        destroyCards.AddRange(Graveyard);
        destroyCards.AddRange(Deck.Cards);
        var nonNullTrackCards = Track.Cards.Where(x => x.Value != null);
        if(nonNullTrackCards.Any())
        {
            destroyCards.AddRange(nonNullTrackCards.Select(x => x.Value)!);
        }
        //NOTE: KEEP INVENTORY + EQUIPMENT

        foreach (var c in destroyCards)
        {
            AllCards.Remove(c.ID);
            c.DestroyCardEntity();
        }
        DiscardStack.Clear();
        Graveyard.Clear();

        Deck.Init();
        Track.Init();

        Logic.MetaEvents.DrawingMultipleCards.Emit(Systems.Logic.RootEvent, postExecution: e =>
        {
            for (int i = 0; i < Track.MaxTrackCards; i++)
            {
                Depot.Generated.dungeon.logicTriggers.draw.Emit(e);
            }
        }, onComplete: () =>
        {
            Coroutines.Start(Track.MoveTrackCardsToLatestTrackPositions(),"initial track card movement");
        });
    }

    public static Dictionary<int, DeckCard> AllCards = new();
    public static DeckCard CreateNewCard(string name, Depot.Generated.dungeon.cards.cardsLine data)
    {
        var card = new DeckCard(AllCards.Count, name, data);
        AllCards.Add(AllCards.Count,card);
        return card;
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
            Text($"Fullness:{Player.Fullness}");

            Button($"Move", buttonSize, () =>
            {
                Events.Commands.Execute?.Invoke(new PlayerInputCommands.Move());
            });
            // if (!Track.Cards.All(x => x.IsObstacle))
            // {
                //DONE shouldnt be able to move if all track cards are obstacles
                //DONE moving heals
                //DONE moving increases hunger
                //moving gets an attack of opportuninty if "trapped"
                //DONE move cycles a card from track (if possible)
                //DONE move draws if able
            // }
            // else
            // {
            //     Text($"cant move, all are obstacles");
            // }
                
            Button($"Wait", buttonSize, () =>
            {
                Events.Commands.Execute?.Invoke(new PlayerInputCommands.Wait());
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
            
            
            SeperatorText("track cards");
            foreach (var e in Track.Cards)
            {
                var slotname = e.Value != null ? e.Value.Name : "Empty";
                Text($"{e.Key}:{slotname}");
            }
            SeperatorText("off track cards");
            foreach (var e in DiscardStack)
            {
                Text($"{e.Name}");
            }
            SeperatorText("graveyard");
            foreach (var e in Graveyard)
            {
                Text($"{e.Name}");
            }
            SeperatorText("deck cards");
            foreach (var e in Deck.Cards)
            {
                Text($"{Deck.Cards.IndexOf(e)}:{e.Name}");
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