using System.Collections;
using System.Numerics;
using Dinghy.Core;

namespace Dinghy.Sandbox.Demos.dungeon;

public class Effects
{
    public struct ShakeParams()
    {
        public float Multiplier = 1f;
        public float BaseShake = 12f;
        public float Tick = 0.001f;
        public float Decay = 190f;
        public float DeathTime = 0.1f;
    }
    
    public ShakeParams defaultShake = new ShakeParams();
    public IEnumerator Shake(DeckCard c) => Shake(c, defaultShake);
    public IEnumerator Shake(DeckCard c, ShakeParams p)
    {
        c.Entity.ColliderActive = false;
        Vector2 start = new Vector2(c.Entity.X, c.Entity.Y);
        TimeSince t = 0;
        TimeSince shakeTimer = 0;
        while (t < p.DeathTime)
        {
            if (shakeTimer >= p.Tick)
            {
                var next = start + Quick.RandUnitCircle() * p.BaseShake * p.Multiplier;
                c.Entity.X = next.X;
                c.Entity.Y = next.Y;
                shakeTimer = 0f;
            }
            
            p.BaseShake -= p.Decay * (float)Engine.DeltaTime;
            p.BaseShake = MathF.Max( p.BaseShake, 0 );
            yield return null;
        }
        c.Entity.X = start.X;
        c.Entity.Y = start.Y;
        c.Entity.ColliderActive = true;
    }
}