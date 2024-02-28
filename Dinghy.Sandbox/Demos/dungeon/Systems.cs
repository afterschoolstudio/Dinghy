using System.Reflection;
using Arch.CommandBuffer;
using Arch.Core;
using Arch.Core.Extensions;
using Dinghy.Core;
using Dinghy.Internal.Sokol;
using Volatile;

namespace Dinghy.Sandbox.Demos.dungeon;

public partial class Systems
{
    public static void Init()
    {
        Engine.RegisterSystem(new GameLogicSystem());
        // Engine.RegisterSystem(new CollisionSystem());
        // Engine.RegisterSystem(new MouseEnemyCollisonHandler());
    }
}