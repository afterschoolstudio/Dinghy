using System.Collections;

namespace Dinghy.Core;

public static class Coroutines
{
    public static void Start(IEnumerator c, Action completionCallback = null)
    {
        Engine.ECSWorld.Create(
            new Coroutine(c,completionCallback)
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