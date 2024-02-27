using System.Collections;

namespace Dinghy.Core;

public static class Coroutines
{
    public static void Add(IEnumerator c)
    {
        Engine.ECSWorld.Create(
            new Coroutine(c)
        );
    }
}