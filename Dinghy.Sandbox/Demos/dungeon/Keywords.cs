using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Dinghy.Sandbox.Demos.dungeon;

public static class Keywords
{
    public class KeywordBindingAttribute : System.Attribute
    {
        public string KeywordID { get; protected set; }
        public KeywordBindingAttribute(string keywordID)
        {
            KeywordID = keywordID;
        }
    }

    public static Dictionary<string, MethodInfo> KeywordBindingDict = new Dictionary<string, MethodInfo>();
    public static void InitBindings()
    {
        // Get all methods in the current class
        foreach (var method in typeof(Keywords).GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance))
        {
            // Check if the method has the KeywordBinding attribute
            var attribute = method.GetCustomAttribute<KeywordBindingAttribute>();
            if (attribute != null && method.IsStatic && method.ReturnType == typeof(IEnumerator))
            {
                KeywordBindingDict.Add(attribute.KeywordID, method);
            }
        }
    }
    public static Systems.Logic.Event Emit(
        this Depot.Generated.dungeon.keywords.keywordsLine keyword, 
        Systems.Logic.Event parent,
        Systems.Logic.EventData? data = null)
    {
        if (KeywordBindingDict.TryGetValue(keyword.ID, out MethodInfo methodInfo))
        {
            var newEvent = new Systems.Logic.Event(keyword.ID, (IEnumerator)methodInfo.Invoke(null, [Systems.Logic.GetCurrentEventCounter(),data]));
            parent.ChildEvents.Add(newEvent);
            // For static methods, the first parameter is null. For instance methods, you need an instance.
            return newEvent;
        }
        throw new KeyNotFoundException($"No method bound to keyword {keyword.ID}.");
    }
    
    [KeywordBinding("rejuvenate")]
    public static IEnumerator Rejuvenate(int eventID, Systems.Logic.EventData? d)
    {
        Dungeon.Player.Health += 1;
        yield return null;
    }
        
    [KeywordBinding("vengeance")]
    public static IEnumerator Vengeance(int eventID, Systems.Logic.EventData? d)
    {
        var card = Dungeon.AllCards[d.cardID];
        Dungeon.DiscardStack.Remove(card);
        //TODO: non jam version: yield return Dungeon.MoveCard(card, Dungeon.CardLocation.Deck, 0);
        Dungeon.Deck.Cards.Insert(0, card);
        yield return null;
    }
     
    [KeywordBinding("cycles")]
    public static IEnumerator Cycles(int eventID, Systems.Logic.EventData? d)
    {
        var card = Dungeon.AllCards[d.cardID];
        Dungeon.DiscardStack.Remove(card);
        Dungeon.Deck.Cards.Add(card);
        yield return null;
    }
    [KeywordBinding("obstacle")]
    public static IEnumerator Obstacle(int eventID, Systems.Logic.EventData? d)
    {
        // need to tie this into global state
        // parent.Cancelled = !Dungeon.Track.Cards.Any(x =>
        //     x.Value != null && !x.Value.Keywords.Contains(Depot.Generated.dungeon.keywords.obstacle));
        yield return null;
    }
    [KeywordBinding("exit")]
    public static IEnumerator Exit(int eventID, Systems.Logic.EventData? d)
    {
        Dungeon.NextDungeonRoom();
        yield return null;
    }
}