using System.Collections;

namespace Dinghy.Core;

public static class Coroutines
{
    public static void Start(IEnumerator c, string name, Action completionCallback = null)
    {
        Engine.ECSWorld.Create(
            new Coroutine(c,name,completionCallback)
        );
    }

    public static IEnumerator WaitForSeconds(float seconds)
    {
        TimeSince ts = 0;
        while (ts < seconds)
        {
            yield return null;
        }
    }
}