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
            if (attribute != null && method.IsStatic && method.ReturnType == typeof(IEnumerator) && method.GetParameters().Length == 0)
            {
                KeywordBindingDict.Add(attribute.KeywordID, method);
            }
        }
    }
    public static Systems.Logic.Event Emit(this Depot.Generated.dungeon.keywords.keywordsLine keyword, Systems.Logic.Event parent)
    {
        if (KeywordBindingDict.TryGetValue(keyword.ID, out MethodInfo methodInfo))
        {
            // For static methods, the first parameter is null. For instance methods, you need an instance.
            return new Systems.Logic.Event(parent, (IEnumerator)methodInfo.Invoke(null, null));
        }
        throw new KeyNotFoundException($"No method bound to keyword '{keyword}'.");
    }
    
    [KeywordBinding("rejuvenate")]
    public static IEnumerator Rejuvenate()
    {
        Dungeon.Player.Health += 1;
        yield return null;
    }
        
    [KeywordBinding("vengeance")]
    public static IEnumerator Vengeance()
    {
        Dungeon.Track.RemoveTrackCard(Dungeon.AllCards[data.cardID]);
        Dungeon.Deck.Cards.Insert(0, Dungeon.AllCards[data.cardID]);
        yield return null;
    }
     
    [KeywordBinding("cycles")]
    public static IEnumerator Cycles()
    {
        Dungeon.Track.RemoveTrackCard(Dungeon.AllCards[data.cardID]);
        Dungeon.Deck.Cards.Add(Dungeon.AllCards[data.cardID]);
        yield return null;
    }
    [KeywordBinding("obstacle")]
    public static IEnumerator Obstacle()
    {
        // need to tie this into global state
        // parent.Cancelled = !Dungeon.Track.Cards.Any(x =>
        //     x.Value != null && !x.Value.Keywords.Contains(Depot.Generated.dungeon.keywords.obstacle));
        yield return null;
    }
    [KeywordBinding("exit")]
    public static IEnumerator Exit()
    {
        Dungeon.NextDungeonRoom();
        yield return null;
    }
}