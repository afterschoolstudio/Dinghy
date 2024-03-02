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
}