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
        Engine.RegisterSystem(new ShakeSystem());
        Engine.RegisterSystem(new GameLogicSystem());
        // Engine.RegisterSystem(new CollisionSystem());
        // Engine.RegisterSystem(new MouseEnemyCollisonHandler());
    }

    public struct Shake
    {
        public float Multiplier = 1f;
        public float BaseShake = 12f;
        public float Tick = 0.001f;
        public float Decay = 190f;
        public float DeathTime = 0.2f;
        public TimeSince ShakeTimer = 0;
        public TimeSince Runtime = 0f;
        public Shake(){}

        public Vector2 start;
        public bool baseAssigned;
        public void AssignBasePos(float x, float y)
        {
            start = new Vector2(x, y);
            baseAssigned = true;
        }

        public Vector2 NextShake()
        {
            return start + Quick.RandUnitCircle() * BaseShake * Multiplier;
        }
    }
    public class ShakeSystem : DSystem, IUpdateSystem
    {
        QueryDescription query = new QueryDescription().WithAll<Active,Shake,Position>();
        public void Update(double dt)
        {
            var buffer = new CommandBuffer(Engine.ECSWorld);
            Engine.ECSWorld.Query(in query, (Arch.Core.Entity e, ref Active a, ref Shake s, ref Position p) => {
                if(!a.active){return;}
                if(!s.baseAssigned){s.AssignBasePos(p.x,p.y);}
                if (s.Runtime >= s.DeathTime) 
                {
                    buffer.Remove<Shake>(in e);
                    p.x = s.start.x;
                    p.y = s.start.y;
                }
                else
                {
                    if (s.ShakeTimer >= s.Tick)
                    {
                        var next = s.NextShake();
                        p.x = next.x;
                        p.y = next.y;
                        s.ShakeTimer = 0f;
                    }

                    s.BaseShake -= s.Decay * (float)dt;
                    s.BaseShake = MathF.Max( s.BaseShake, 0 );
                }
            });
            buffer.Playback();
        }
    }
}