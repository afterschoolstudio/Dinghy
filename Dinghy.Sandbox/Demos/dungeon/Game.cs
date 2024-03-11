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

    public static int CurrentFloor = 1;
    public static bool GameSetup = false;
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
            Logic.MetaEvents.UpdateCardPositions.Emit(Systems.Logic.RootEvent, onComplete: () =>
            {
                Console.WriteLine("init pos update complete");
                GameSetup = true;
            });
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
                Inventory.RemoveFromInventory(c);
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
        GameSetup = false;
        Console.WriteLine("next dungeon room");
        CurrentFloor++;
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
            Logic.MetaEvents.UpdateCardPositions.Emit(Systems.Logic.RootEvent, onComplete: () =>
            {
                Console.WriteLine("init pos update complete");
                GameSetup = true;
            });
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
                Checkbox("Show Piles", ref ActiveDebugOptions.ShowPiles);
                Button($"Reset", buttonSize, Init);
            });
        });

        if (GameSetup)
        {
            var window_flags = ImGuiWindowFlags_.ImGuiWindowFlags_NoDecoration | ImGuiWindowFlags_.ImGuiWindowFlags_NoDocking | ImGuiWindowFlags_.ImGuiWindowFlags_AlwaysAutoResize | ImGuiWindowFlags_.ImGuiWindowFlags_NoSavedSettings | ImGuiWindowFlags_.ImGuiWindowFlags_NoFocusOnAppearing | ImGuiWindowFlags_.ImGuiWindowFlags_NoNav;
            SetNextWindowPosition(new Vector2(10,110));
            Window("game", window_flags, () =>
            {
                if (Player.Dead)
                {
                    Text($"player died");
                    Button($"Reset", buttonSize, Init);
                    return;
                }

                Text($"HP: {Player.Health}/{Player.MaxHealth}");
                Text($"Fullness:{Player.Fullness}");
                Text($"Current Floor:{CurrentFloor}");

                if (Track.Cards[0] != null && !Track.Cards[0].Keywords.Any(x => x.ID == "obstacle"))
                {
                    Button($"Move", buttonSize,
                        () => { Events.Commands.Execute?.Invoke(new PlayerInputCommands.Move()); });
                }

                Button($"Wait", buttonSize, () => { Events.Commands.Execute?.Invoke(new PlayerInputCommands.Wait()); });

                SeperatorText("track cards");
                foreach (var e in Track.Cards)
                {
                    var slotname = e.Value != null ? e.Value.Name : "Empty";
                    Text($"{e.Key}:{slotname}");
                }

                SeperatorText("inventory");
                foreach (var e in Inventory.Cards.Where(x => x.Value != null))
                {
                    Text($"{e.Key}:{e.Value.Name}");
                }

                SeperatorText("discard");
                foreach (var e in DiscardStack)
                {
                    Text($"{e.Name}");
                }

                SeperatorText("graveyard");
                foreach (var e in Graveyard)
                {
                    Text($"{e.Name}");
                }

                if (ActiveDebugOptions.ShowPiles)
                {
                    SeperatorText("deck cards");
                    foreach (var e in Deck.Cards)
                    {
                        Text($"{Deck.Cards.IndexOf(e)}:{e.Name}");
                    }
                }
            });
        }
    }

    public class DebugOptions
    {
        public bool DontDamageEnemies;
        public bool Invincible;
        public bool ShowPiles;
    }
}