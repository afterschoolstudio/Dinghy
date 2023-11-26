﻿using Arch.Core;
using Dinghy.Internal.Sokol;

namespace Dinghy;

public class DSystem {}
public interface IPreUpdateSystem
{
    void PreUpdate(double dt);
}
public interface IUpdateSystem
{
    void Update(double dt);
}
public interface IPostUpdateSystem
{
    void PostUpdate(double dt);
}
public interface ICleanupSystem
{
    void Cleanup(double dt);
}

public class ManagedComponentSystem : DSystem, IPreUpdateSystem, IPostUpdateSystem, IUpdateSystem
{
    QueryDescription query = new QueryDescription().WithAll<Active,ManagedComponent>();      // Should have all specified components
    public void PreUpdate(double dt)
    {
        Engine.World.Query(in query, (Arch.Core.Entity e, ref ManagedComponent c) => {
            c.managedComponent.PreUpdate();
        });
    }
    public void Update(double dt)
    {
        Engine.World.Query(in query, (Arch.Core.Entity e, ref ManagedComponent c) => {
            c.managedComponent.Update();
        });
    }
    public void PostUpdate(double dt)
    {
        Engine.World.Query(in query, (Arch.Core.Entity e, ref ManagedComponent c) => {
            c.managedComponent.PostUpdate();
        });
    }
}
public class VelocitySystem : DSystem, IUpdateSystem
{
    QueryDescription query = new QueryDescription().WithAll<Active,HasManagedOwner,Position, Velocity>();      // Should have all specified components
    QueryDescription bunny = new QueryDescription().WithAll<Active,HasManagedOwner,Position, Velocity,BunnyMark>();      // Should have all specified components
    public void Update(double dt)
    {
        Engine.World.Query(in query, (Arch.Core.Entity e, ref HasManagedOwner owner, ref Position pos, ref Velocity vel) => {
            pos.x = (int)(pos.x + vel.x);
            pos.y = (int)(pos.y + vel.y);
            //could maybe grab stuff like this at the top of the frame so an entity
            //has the most recent pos stuff at the start instead of changing it mid frame?
            owner.e.SetPositionRaw(pos.x,pos.y,pos.rotation,pos.scaleX,pos.scaleY);
        });
        
        Engine.World.Query(in bunny, (Arch.Core.Entity e, ref HasManagedOwner owner,  ref Position pos, ref Velocity vel) => {
            vel.y += 9.8f;
            
            if (pos.x > Engine.Width)
            {
                vel.x *= -1;
                pos.x = Engine.Width;
            }
            else if (pos.x < 0)
            {
                vel.x *= -1;
                pos.x = 0;
            }
            
            if (pos.y > Engine.Height)
            {
                vel.y *= -0.85f;
                pos.y = Engine.Height;
                if (Quick.RandFloat() > 0.5)
                {
                    vel.y -= (Quick.RandFloat() * 6);
                }
            }
            else if (pos.y < 0)
            {
                vel.y = 0;
                pos.y = 0;
            }
            owner.e.SetPositionRaw(pos.x,pos.y,pos.rotation,pos.scaleX,pos.scaleY);
        });
    }
}
public abstract class RenderSystem : DSystem, IUpdateSystem
{
    public void Update(double dt)
    {
        Render(dt);
    }

    protected abstract void Render(double dt);
}
public class SpriteRenderSystem : RenderSystem
{
    QueryDescription query = new QueryDescription().WithAll<Active,Position,SpriteRenderer>();      // Should have all specified components
    protected override void Render(double dt)
    {
        Engine.World.Query(in query, (Arch.Core.Entity e, ref SpriteRenderer r, ref Position p) =>
        {
            if (!r.ImageResource.loaded)
            {
                r.ImageResource.Load();
            }
            Engine.DrawTexturedRect(p.x, p.y,p.rotation,p.scaleX, p.scaleY,r.Frame,r.ImageResource);
        });
    }
}

public class ShapeRenderSystem : RenderSystem
{
    QueryDescription query = new QueryDescription().WithAll<Active,Position,ShapeRenderer>();      // Should have all specified components
    protected override void Render(double dt)
    {
        Engine.World.Query(in query, (Arch.Core.Entity e, ref ShapeRenderer r, ref Position p) =>
        {
            Engine.DrawShape(p.x, p.y,p.rotation, p.scaleX, p.scaleY, r.Color, new Frame(0,0,(int)r.Width,(int)r.Height));
        });
    }
}

public class ParticleRenderSystem : RenderSystem
{
    QueryDescription query = new QueryDescription().WithAll<Active,Position,ParticleEmitterComponent>();      // Should have all specified components
    protected override void Render(double dt)
    {
        Engine.World.Query(in query, (Arch.Core.Entity e, ref Position p, ref ParticleEmitterComponent emitter) =>
        {
            //update the particles
            List<int> activeIndicies = new List<int>();
            var dt = (float)Engine.DeltaTime;
            int emitted = 0;
            var possibleParticleSlots = emitter.Config.emissionRate * dt;
            emitter.Accumulator += possibleParticleSlots;
            var freeSlots = (int)emitter.Accumulator;
            for (int i = 0; i < emitter.Particles.Count; i++)
            {
                bool justInit = false;
                if(freeSlots > 0 && !emitter.Particles[i].Active)
                {
                    emitter.Particles[i].Active = true;
                    emitter.Particles[i].Init();
                    justInit = true;
                    freeSlots--;
                    emitter.Accumulator--;
                }

                if (!justInit)
                {
                    emitter.Particles[i].Age += dt;
                    if (emitter.Particles[i].Age > emitter.Config.particleConfig.lifespan)
                    {
                        emitter.Particles[i].Active = false;
                    }
                }

                if (emitter.Particles[i].Active)
                {
                    activeIndicies.Add(i);
                    emitter.Particles[i].X += emitter.Particles[i].DX;
                    emitter.Particles[i].Y += emitter.Particles[i].DY;
                }
            }
            
            
            //draw the particles
            Engine.DrawParticles(p, emitter, activeIndicies);
        });
    }
}

public class InputSystem : DSystem, IUpdateSystem
{
    public static float MouseX;
    public static float MouseY;
    public static class Events
    {
        public static class Key
        {
            public static Action<Dinghy.Key> Pressed;
            public static Action<Dinghy.Key> Down;
            public static Action<Dinghy.Key> Up;
        }
    }
    public HashSet<sapp_event> FrameEvents = new HashSet<sapp_event>();
    public void Update(double dt)
    {
        foreach (var e in FrameEvents)
        {
            switch (e.type)
            {
                case sapp_event_type.SAPP_EVENTTYPE_INVALID:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_KEY_DOWN:
                    if (e.key_repeat > 0)
                    {
                        Events.Key.Pressed?.Invoke((Key)e.key_code);
                    }
                    Events.Key.Down?.Invoke((Key)e.key_code);
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_KEY_UP:
                    Events.Key.Up?.Invoke((Key)e.key_code);
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_CHAR:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_MOUSE_DOWN:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_MOUSE_UP:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_MOUSE_SCROLL:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_MOUSE_MOVE:
                    MouseX = e.mouse_x;
                    MouseY = e.mouse_y;
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_MOUSE_ENTER:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_MOUSE_LEAVE:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_TOUCHES_BEGAN:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_TOUCHES_MOVED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_TOUCHES_ENDED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_TOUCHES_CANCELLED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_RESIZED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_ICONIFIED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_RESTORED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_FOCUSED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_UNFOCUSED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_SUSPENDED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_RESUMED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_QUIT_REQUESTED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_CLIPBOARD_PASTED:
                    break;
                case sapp_event_type.SAPP_EVENTTYPE_FILES_DROPPED:
                    break;
            }
            // Console.WriteLine(e.type);
        }
        FrameEvents.Clear();
    }
}

public abstract class AnimationSystem : DSystem, IPreUpdateSystem
{
    public void PreUpdate(double dt)
    {
        Animate(dt);
    }

    protected abstract void Animate(double dt);
}

public class FrameAnimationSystem : AnimationSystem
{
    QueryDescription query = new QueryDescription().WithAll<Active,SpriteRenderer,SpriteAnimator>();
    protected override void Animate(double dt)
    {
        Engine.World.Query(in query, (Arch.Core.Entity e, ref SpriteRenderer r, ref SpriteAnimator a) =>
        {
            if (a.AnimationStarted == false)
            {
                //we do this to pump the first animation frame to the renderer so we dont render the whole texture first
                a.AnimationStarted = true;
                r.UpdateFrame(a.CurrentAnimationFrame);
            }
            else
            {
                a.AnimationTime += dt;
                if (!(a.AnimationTime > a.CurrentAnimation.FrameTime)) return;
                a.TickAnimation();
                    
                //note that there is currently no binding glue to imply that SpriteAnimator will work directly on an attached SpriteRenderer
                r.UpdateFrame(a.CurrentAnimationFrame);
                a.AnimationTime = 0;
            }
        });
    }
}

public class DestructionSystem : DSystem, ICleanupSystem
{
    QueryDescription query = new QueryDescription().WithAll<Destroy>();
    QueryDescription managedCleanupQuery = new QueryDescription().WithAll<Destroy,HasManagedOwner>();
    public void Cleanup(double dt)
    {
        Engine.World.Query(in managedCleanupQuery, (Arch.Core.Entity e, ref HasManagedOwner owner) =>
        {
            Engine.GlobalScene.Entities.Remove(owner.e); //TODO: note this assumes a global scene
        });
        Engine.World.Destroy(in query);
    }
}

public class BasicCollisionSystem : DSystem, IUpdateSystem
{
    QueryDescription query = new QueryDescription().WithAll<Collider,Position>();
    public void Update(double dt)
    {
        Engine.World.Query(in query, (Arch.Core.Entity e, ref Collider c, ref Position a) =>
        {
            //get collider position
            // c.f.
        });
    }

}

