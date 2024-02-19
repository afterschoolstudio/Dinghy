using System.Diagnostics;
using System.Numerics;
using Arch.Core;
using Arch.Core.Extensions;
using Dinghy.Core;
using Dinghy.Core.ImGUI;
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
    void Cleanup();
}

public class ManagedComponentSystem : DSystem, IPreUpdateSystem, IPostUpdateSystem, IUpdateSystem
{
    QueryDescription query = new QueryDescription().WithAll<Active,ManagedComponent>();      // Should have all specified components
    public void PreUpdate(double dt)
    {
        Engine.ECSWorld.Query(in query, (Arch.Core.Entity e, ref Active a, ref ManagedComponent c) =>
        {
            if (!a.active) { return;}
            c.managedComponent.PreUpdate();
        });
    }
    public void Update(double dt)
    {
        Engine.ECSWorld.Query(in query, (Arch.Core.Entity e,ref Active a,  ref ManagedComponent c) => {
            if (!a.active) { return;}
            c.managedComponent.Update();
        });
    }
    public void PostUpdate(double dt)
    {
        Engine.ECSWorld.Query(in query, (Arch.Core.Entity e,ref Active a,  ref ManagedComponent c) => {
            if (!a.active) { return;}
            c.managedComponent.PostUpdate();
        });
    }
}

public class VelocitySystem : DSystem, IUpdateSystem
{
    QueryDescription query = new QueryDescription().WithAll<Active,HasManagedOwner,Position, Velocity>();      // Should have all specified components
    public void Update(double dt)
    {
        Engine.ECSWorld.Query(in query, (Arch.Core.Entity e, ref Active a, ref HasManagedOwner owner, ref Position pos, ref Velocity vel) => {
            if(!a.active){return;}
            pos.x += vel.x;
            pos.y += vel.y;
            owner.e.SetPositionRaw(pos.x,pos.y,pos.rotation,pos.scaleX,pos.scaleY,pos.pivotX,pos.pivotY);
        });
    }
}

public class SceneSystem : DSystem, IUpdateSystem
{
    QueryDescription query = new QueryDescription().WithAll<Active,SceneComponent>();      // Should have all specified components
    public void Update(double dt)
    {
        Engine.ECSWorld.Query(in query, (Arch.Core.Entity e, ref Active a, ref SceneComponent scene) => {
            if(!a.active){return;}
            if (Engine.MountedScenes.ContainsValue(scene.ManagedScene) && scene.ManagedScene.Status == Scene.SceneStatus.Running)
            {
                scene.Update(dt);
            }
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
        Engine.ECSWorld.Query(in query, (Arch.Core.Entity e, ref Active a, ref SpriteRenderer r, ref Position p) =>
        {
            if(!a.active){return;}
            if (!r.Texture.DataLoaded)
            {
                r.Texture.Load();
            }
            Engine.DrawTexturedRect(p,r);
        });
    }
}

public class ShapeRenderSystem : RenderSystem
{
    QueryDescription query = new QueryDescription().WithAll<Active,Position,ShapeRenderer>();      // Should have all specified components
    protected override void Render(double dt)
    {
        Engine.ECSWorld.Query(in query, (Arch.Core.Entity e,ref Active a,  ref ShapeRenderer r, ref Position p) =>
        {
            if(!a.active){return;}
            Engine.DrawShape(p, r);
        });
    }
}

public class ParticleRenderSystem : RenderSystem
{
    QueryDescription query = new QueryDescription().WithAll<Active,Position,ParticleEmitterComponent>();      // Should have all specified components
    protected override void Render(double dt)
    {
        Engine.ECSWorld.Query(in query, (Arch.Core.Entity e, ref Position p,ref Active a,  ref ParticleEmitterComponent emitter) =>
        {
            if(!a.active){return;}
            // Update the particles
            List<int> activeIndices = new List<int>();
            // List<int> newIndicies = new List<int>();
            var possibleParticleSlots = emitter.Config.EmissionRate * dt;
            emitter.Accumulator += possibleParticleSlots;
            var freeSlots = (int)emitter.Accumulator;

            // Reactivate old inactive particles if possible
            for (int i = 0; i < emitter.Particles.Count; i++)
            {
                if (emitter.Particles[i].Active)
                {
                    emitter.Particles[i].Age += dt;
                    if (emitter.Particles[i].Age > emitter.Config.ParticleConfig.Lifespan)
                    {
                        //staged for inactive
                        if (freeSlots == 0)
                        {
                            //go inactive if no free slots
                            emitter.Particles[i].Active = false;
                            continue;
                        }
                        
                        //otherwise remake this particle
                        emitter.Particles[i].Reset();
                        emitter.Particles[i].Config = new ParticleEmitterComponent.ParticleConfig(emitter.Config.ParticleConfig);
                        emitter.Particles[i].Config.EmissionPoint = new(p.x, p.y);
                        emitter.Particles[i].Resolve();
                
                        activeIndices.Add(i);
                        freeSlots--;
                        emitter.Accumulator--;
                    }

                    else
                    {
                        //particle still active
                        emitter.Particles[i].Resolve();
                        emitter.Particles[i].X += emitter.Particles[i].DX;
                        emitter.Particles[i].Y += emitter.Particles[i].DY;
                        activeIndices.Add(i);
                    }
                }
                else if (freeSlots > 0)
                {
                    //reset and toggle to active if there is a slot 
                    emitter.Particles[i].Reset();
                    emitter.Particles[i].Active = true;
                    emitter.Particles[i].Config = new ParticleEmitterComponent.ParticleConfig(emitter.Config.ParticleConfig);
                    emitter.Particles[i].Config.EmissionPoint = new(p.x, p.y);
                    emitter.Particles[i].Resolve();
                
                    activeIndices.Add(i);
                    freeSlots--;
                    emitter.Accumulator--;
                }
            }

            // Create new particles if needed and maximum limit is not reached
            while (freeSlots > 0 && emitter.Particles.Count < emitter.Config.MaxParticles)
            {
                ParticleEmitterComponent.Particle newParticle = new();
                newParticle.Active = true;
                emitter.Particles.Add(newParticle);
                newParticle.Resolve();
                activeIndices.Add(emitter.Particles.Count - 1);
                freeSlots--;
                emitter.Accumulator--;
            }

            // Draw the particles
            if (activeIndices.Count > 0)
            {
                Engine.DrawParticles(p, emitter, activeIndices);
            }
        });
    }
}

public class InputSystem : DSystem, IUpdateSystem
{
    QueryDescription
        frameEvents = new QueryDescription().WithAll<EventMeta, FrameEvent>(); // Should have all specified components



    public enum MouseState
    {
        Up,
        Pressed,
        Scroll,
        Down
    }
    public static float MouseX;
    public static float MouseY;
    public static class Events
    {
        public static class Key
        {
            public static Action<Dinghy.Key,List<Modifiers>> Pressed;
            public static Action<Dinghy.Key, List<Modifiers>> Down;
            public static Action<Dinghy.Key, List<Modifiers>> Up;
            public static Action<uint> Char;
        }

        public static class Mouse
        {
            public static Action<List<Modifiers>> Down;
            public static Action<List<Modifiers>> Pressed;
            public static Action<List<Modifiers>> Up;
            public static Action<float,float,float,float,List<Modifiers>> Move;
            public static Action<float,float,List<Modifiers>> Scroll;
        }

        public static class Window
        {
            public static Action<List<Modifiers>> MouseEnter;
            public static Action<List<Modifiers>> MouseLeave;
            public static Action Resized;
            public static Action Focused;
            public static Action Unfocused;
            public static Action Suspended;
            public static Action Resumed;
            public static Action RequestedQuit;
        }
    }

    private bool lmb_up = true;
    private bool rmb_up = true;
    private bool mmb_up = true;

    public void Update(double dt)
    {
        Engine.ECSWorld.Query(in frameEvents, (Arch.Core.Entity entity, ref EventMeta em, ref FrameEvent frameEvent) =>
        {
            if(!em.dirty)
            {
                var mods = GetModifier(frameEvent.e.modifiers);
                switch (frameEvent.e.type)
                {
                    case sapp_event_type.SAPP_EVENTTYPE_INVALID:
                        break;
                    case sapp_event_type.SAPP_EVENTTYPE_KEY_DOWN:
                        if (frameEvent.e.key_repeat > 0)
                        {
                            Events.Key.Pressed?.Invoke((Key)frameEvent.e.key_code,mods);
                        }
                        Events.Key.Down?.Invoke((Key)frameEvent.e.key_code,mods);
                        break;
                    case sapp_event_type.SAPP_EVENTTYPE_KEY_UP:
                        Events.Key.Up?.Invoke((Key)frameEvent.e.key_code,mods);
                        break;
                    case sapp_event_type.SAPP_EVENTTYPE_CHAR:
                        Events.Key.Char?.Invoke(frameEvent.e.char_code);
                        break;
                    case sapp_event_type.SAPP_EVENTTYPE_MOUSE_DOWN:

                        MouseButton downButton = frameEvent.e.mouse_button switch
                        {
                            sapp_mousebutton.SAPP_MOUSEBUTTON_LEFT => downButton = MouseButton.LEFT,
                            sapp_mousebutton.SAPP_MOUSEBUTTON_RIGHT => downButton = MouseButton.RIGHT,
                            sapp_mousebutton.SAPP_MOUSEBUTTON_MIDDLE => downButton = MouseButton.MIDDLE,
                            _ => MouseButton.INVALID,
                        };

                        bool createPressedEvent = false;
                        switch (downButton)
                        {
                            case MouseButton.MIDDLE when mmb_up:
                                createPressedEvent = true;
                                mmb_up = false;
                                break;
                            case MouseButton.LEFT when lmb_up:
                                createPressedEvent = true;
                                lmb_up = false;
                                break;
                            case MouseButton.RIGHT when rmb_up:
                                createPressedEvent = true;
                                rmb_up = false;
                                break;
                        }

                        if (createPressedEvent)
                        {
                            Events.Mouse.Pressed?.Invoke(mods);
                            Engine.ECSWorld.Create(
                                new EventMeta("MOUSE_PRESSED"),
                                new MouseEvent(MouseState.Pressed,downButton,mods));
                        }
                        Events.Mouse.Down?.Invoke(mods);
                        Engine.ECSWorld.Create(
                            new EventMeta("MOUSE_DOWN"),
                            new MouseEvent(MouseState.Down,downButton,mods));
                        break;
                    case sapp_event_type.SAPP_EVENTTYPE_MOUSE_UP:
                        
                        MouseButton upButton = frameEvent.e.mouse_button switch
                        {
                            sapp_mousebutton.SAPP_MOUSEBUTTON_LEFT => downButton = MouseButton.LEFT,
                            sapp_mousebutton.SAPP_MOUSEBUTTON_RIGHT => downButton = MouseButton.RIGHT,
                            sapp_mousebutton.SAPP_MOUSEBUTTON_MIDDLE => downButton = MouseButton.MIDDLE,
                            _ => MouseButton.INVALID,
                        };

                        switch (upButton)
                        {
                            case MouseButton.MIDDLE:
                                mmb_up = true;
                                break;
                            case MouseButton.LEFT:
                                lmb_up = true;
                                break;
                            case MouseButton.RIGHT:
                                rmb_up = true;
                                break;
                        }
                        Events.Mouse.Up?.Invoke(mods);
                        Engine.ECSWorld.Create(
                            new EventMeta("MOUSE_UP"),
                            new MouseEvent(MouseState.Up,upButton,mods));
                        break;
                    case sapp_event_type.SAPP_EVENTTYPE_MOUSE_SCROLL:
                        Events.Mouse.Scroll?.Invoke(frameEvent.e.scroll_x,frameEvent.e.scroll_y,mods);
                        Engine.ECSWorld.Create(
                            new EventMeta("MOUSE_SCROLL"),
                            new MouseEvent(MouseState.Scroll, MouseButton.INVALID, mods, frameEvent.e.scroll_x, frameEvent.e.scroll_y));
                        break;
                    case sapp_event_type.SAPP_EVENTTYPE_MOUSE_MOVE:
                        MouseX = frameEvent.e.mouse_x;
                        MouseY = frameEvent.e.mouse_y;
                        Events.Mouse.Move?.Invoke(frameEvent.e.mouse_x,frameEvent.e.mouse_y,frameEvent.e.mouse_dx,frameEvent.e.mouse_dy,mods);
                        break;
                    case sapp_event_type.SAPP_EVENTTYPE_MOUSE_ENTER:
                        Events.Window.MouseEnter?.Invoke(mods);
                        break;
                    case sapp_event_type.SAPP_EVENTTYPE_MOUSE_LEAVE:
                        Events.Window.MouseLeave?.Invoke(mods);
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
                        Events.Window.Resized?.Invoke();
                        break;
                    case sapp_event_type.SAPP_EVENTTYPE_ICONIFIED:
                        break;
                    case sapp_event_type.SAPP_EVENTTYPE_RESTORED:
                        break;
                    case sapp_event_type.SAPP_EVENTTYPE_FOCUSED:
                        Events.Window.Focused?.Invoke();
                        break;
                    case sapp_event_type.SAPP_EVENTTYPE_UNFOCUSED:
                        Events.Window.Unfocused?.Invoke();
                        break;
                    case sapp_event_type.SAPP_EVENTTYPE_SUSPENDED:
                        Events.Window.Suspended?.Invoke();
                        break;
                    case sapp_event_type.SAPP_EVENTTYPE_RESUMED:
                        Events.Window.Resumed?.Invoke();
                        break;
                    case sapp_event_type.SAPP_EVENTTYPE_QUIT_REQUESTED:
                        Events.Window.RequestedQuit?.Invoke();
                        break;
                    case sapp_event_type.SAPP_EVENTTYPE_CLIPBOARD_PASTED:
                        break;
                    case sapp_event_type.SAPP_EVENTTYPE_FILES_DROPPED:
                        break;
                }
            em.dirty = true;
            }
        });
    }
    
    List<Modifiers> GetModifier(uint v)
    {
        var mods = new List<Modifiers>();
        if ((v & App.SAPP_MODIFIER_SHIFT) > 0) mods.Add(Modifiers.SHIFT);
        if ((v & App.SAPP_MODIFIER_CTRL) > 0) mods.Add(Modifiers.CTRL);
        if ((v & App.SAPP_MODIFIER_ALT) > 0) mods.Add(Modifiers.ALT);
        if ((v & App.SAPP_MODIFIER_SUPER) > 0) mods.Add(Modifiers.SUPER);
        if ((v & App.SAPP_MODIFIER_LMB) > 0) mods.Add(Modifiers.LMB);
        if ((v & App.SAPP_MODIFIER_RMB) > 0) mods.Add(Modifiers.RMB);
        if ((v & App.SAPP_MODIFIER_MMB) > 0) mods.Add(Modifiers.MMB);
        return mods;
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
        Engine.ECSWorld.Query(in query, (Arch.Core.Entity e, ref Active act, ref SpriteRenderer r, ref SpriteAnimator a) =>
        {
            if(!act.active){return;}
            if (a.AnimationStarted == false)
            {
                //we do this to pump the first animation frame to the renderer so we dont render the whole texture first
                a.AnimationStarted = true;
                r.UpdateRect(a.CurrentAnimationFrame);
            }
            else
            {
                a.AnimationTime += dt;
                if (!(a.AnimationTime > a.CurrentAnimation.FrameTime)) return;
                a.TickAnimation();
                    
                //note that there is currently no binding glue to imply that SpriteAnimator will work directly on an attached SpriteRenderer
                r.UpdateRect(a.CurrentAnimationFrame);
                a.AnimationTime = 0;
            }
        });
    }
}

public class DestructionSystem : DSystem
{
    QueryDescription query = new QueryDescription().WithAll<Destroy>();
    QueryDescription eventQuery = new QueryDescription().WithAll<CollisionEvent>();
    QueryDescription managedCleanupQuery = new QueryDescription().WithAll<Destroy,HasManagedOwner>();
    public void DestroyObjects()
    {
        Engine.ECSWorld.Query(in managedCleanupQuery, (Arch.Core.Entity e, ref HasManagedOwner owner) =>
        {
            Console.WriteLine("destroying " + owner.e.Name);
            if (owner.e.Scene != null)
            {
                Engine.SceneEntityMap[owner.e.Scene].Remove(owner.e);
            }
        });
        
        Engine.ECSWorld.Query(in eventQuery, (Arch.Core.Entity e, ref CollisionEvent ce) =>
        {
            if (!ce.e1.IsAlive() || !ce.e2.IsAlive() || ce.e1.Entity.Has<Destroy>() || ce.e2.Entity.Has<Destroy>())
            {
                e.Add(new Destroy());
            }
        });
        Engine.ECSWorld.Destroy(in query);
    }
}

public class CollisionCallbackSystem : DSystem, IUpdateSystem
{
    QueryDescription query = new QueryDescription().WithAll<CollisionEvent,CollisionMeta,EventMeta>();
    QueryDescription mouseQuery = new QueryDescription().WithAll<MouseEvent,EventMeta>();
    public void Update(double dt)
    {
        List<MouseEvent> mouseEvents = new List<MouseEvent>();
        Engine.ECSWorld.Query(in mouseQuery, (Arch.Core.Entity e, ref MouseEvent m, ref EventMeta em) =>
        {
            if (!em.dirty)
            {
                // mouseEvents.Add(new MouseEvent(m.mouseState,m.mods,m.scrollX,m.scrollY));
                mouseEvents.Add(m);
            }
        });

        Engine.ECSWorld.Query(in query, (Arch.Core.Entity e, ref CollisionEvent ce, ref CollisionMeta cm, ref EventMeta em) =>
        {
            // Console.WriteLine("HANDLING COLLISION EVENT BETWEEN " + ce.e1.Entity.Get<HasManagedOwner>().e.Name + " and " + ce.e2.Entity.Get<HasManagedOwner>().e.Name + " WITH HASH " + cm.hash);
            if (CollisionEventValid(ref ce))
            {
                bool e1IsCursor = Engine.Cursor.ECSEntityReference.Entity.Id == ce.e1.Entity.Id;
                bool e2IsCursor = Engine.Cursor.ECSEntityReference.Entity.Id == ce.e2.Entity.Id;
                bool finalCollisionValid = false;
                switch (cm.state)
                {
                    case CollisionState.Starting:
                        ce.e1.Entity.Get<Collider>().OnStart?.Invoke(ce.e1,ce.e2);
                        if (CollisionEventValid(ref ce)) {
                            ce.e2.Entity.Get<Collider>().OnStart?.Invoke(ce.e2,ce.e1);
                            if (!CollisionEventValid(ref ce)) {
                                em.dirty = true;
                                cm.state = CollisionState.Invalid;
                            }
                            else
                            {
                                finalCollisionValid = true;
                            }
                        } 
                        else {
                            em.dirty = true;
                            cm.state = CollisionState.Invalid;
                        }
                        break;
                    case CollisionState.Continuing:
                        ce.e1.Entity.Get<Collider>().OnContinue?.Invoke(ce.e1,ce.e2);
                        if (CollisionEventValid(ref ce)) {
                            ce.e2.Entity.Get<Collider>().OnContinue?.Invoke(ce.e2, ce.e1);
                            if (!CollisionEventValid(ref ce)) {
                                em.dirty = true;
                                cm.state = CollisionState.Invalid;
                            }
                            else
                            {
                                finalCollisionValid = true;
                            }
                        }
                        else  {
                            em.dirty = true;
                            cm.state = CollisionState.Invalid;
                        }
    
                        break;
                    case CollisionState.Ending:
                        ce.e1.Entity.Get<Collider>().OnEnd?.Invoke(ce.e1,ce.e2);
                        if (CollisionEventValid(ref ce)) {
                            ce.e2.Entity.Get<Collider>().OnEnd?.Invoke(ce.e2,ce.e1);
                            if (!CollisionEventValid(ref ce)) {
                                em.dirty = true;
                                cm.state = CollisionState.Invalid;
                            }
                            else
                            {
                                finalCollisionValid = true;
                            }
                        }
                        else {
                            em.dirty = true;
                            cm.state = CollisionState.Invalid;
                        }
                        break;
                    case CollisionState.Invalid:
                        em.dirty = true;
                        break;
                }

                if (finalCollisionValid)
                {
                    PropogateMouseEvents(ce.e1.Entity,ce.e2.Entity,e1IsCursor,e2IsCursor);
                }
            }
        });

        bool CollisionEventValid(ref CollisionEvent ce)
        {
            return ce.e1.IsAlive() && ce.e2.IsAlive() && !ce.e1.Entity.Has<Destroy>() && !ce.e2.Entity.Has<Destroy>() &&
                   //this is a hack that gets around a thing i think is happening in arch
                   //where if i destroy an entity as part of collider iteration, something about the collision event itself
                   //updates in memory to point to a different entity, so you get weird things where something is "colliding"
                   //with an event
                   //https://github.com/genaray/Arch/wiki/Utility-Features#command-buffers
                   //"Entity creation, deletion, and structural changes can potentially happen during a query or entity iteration.
                   //However, one must be careful about this, changes to entities during a query can easily lead to unexpected behavior.
                   //A destruction or structural change leads to a copy to another archetype and the current slot is
                   //replaced by another entity. This must always be expected. Depending on when and how you perform these
                   //operations in a query, this can lead to problems or not be noticed at all.
                   ce.e1.Entity.Has<Collider>() && ce.e2.Entity.Has<Collider>();
        }

        void PropogateMouseEvents(Arch.Core.Entity e1, Arch.Core.Entity e2, bool e1IsCursor, bool e2IsCursor)
        {
            if (e1IsCursor || e2IsCursor)
            {
                var target = e1IsCursor ? e2 : e1;
                foreach (var me in mouseEvents)
                {
                    switch (me.mouseState)
                    {
                        case InputSystem.MouseState.Up:
                            target.Get<Collider>().OnMouseUp?.Invoke(me.mods);
                            break;
                        case InputSystem.MouseState.Pressed:
                            target.Get<Collider>().OnMousePressed?.Invoke(me.mods);
                            break;
                        case InputSystem.MouseState.Down:
                            target.Get<Collider>().OnMouseDown?.Invoke(me.mods);
                            break;
                        case InputSystem.MouseState.Scroll:
                            target.Get<Collider>().OnMouseScroll?.Invoke(me.mods,me.scrollX,me.scrollY);
                            break;
                    }
                }
                
            }
        }
    }
}

 public class CollisionSystem : DSystem, IUpdateSystem
{
    QueryDescription query = new QueryDescription().WithAll<Active,Collider,Position>().WithNone<Destroy>();
    QueryDescription colQuery = new QueryDescription().WithAll<EventMeta,CollisionMeta,CollisionEvent>();
    private List<(Arch.Core.Entity e,Collider c,Position p)> colliders = new();
    
    private Dictionary<int, CollisionEvent> bufferedCollisionEvents = new();
    public void Update(double dt)
    {
        colliders.Clear();
        Engine.ECSWorld.Query(in query, (Arch.Core.Entity e, ref Active a, ref Position p, ref Collider c) =>
        {
            if(!c.active || !a.active){return;}
            for (int i = 0; i < colliders.Count; i++)
            {
                if (e.Id != colliders[i].e.Id && Dinghy.Collision.CheckCollision(c,p, colliders[i].c,colliders[i].p))
                {
                    // var hash = HashCode.Combine(e.Id, colliders[i].e.Id);
                    var order = new List<int> { e.Id, colliders[i].e.Id }.OrderDescending();
                    var hash = HashCode.Combine(order.First(), order.Last());
                    var ce = new CollisionEvent(Engine.ECSWorld.Reference(e),
                        Engine.ECSWorld.Reference(colliders[i].e));
                    if (!bufferedCollisionEvents.ContainsKey(hash) && CollisionEventValid(ref ce))
                    {
                        bufferedCollisionEvents.Add(
                            hash, ce);
                    }
                }
            }
            colliders.Add((e,c,p));
        });
        
        Engine.ECSWorld.Query(in colQuery,
            (Arch.Core.Entity e, ref CollisionMeta cm, ref EventMeta em, ref CollisionEvent ce) =>
            {
                if (CollisionEventValid(ref ce) && cm.state != CollisionState.Invalid)
                {
                    em.dirty = false; //keep the event alive
                    if (bufferedCollisionEvents
                        .ContainsKey(cm.hash)) //if we have buffered a collision that already exists
                    {
                        cm.state = CollisionState.Continuing;
                        bufferedCollisionEvents.Remove(cm.hash);
                    }
                    else
                    {
                        cm.state = CollisionState.Ending;
                        em.dirty = true;
                    }
                }
                else
                {
                    //invalid collisions happen if one of the entites is destroyed as part of a callback
                    //in which case we just mark this dirty and dont touch the state
                    em.dirty = true;
                    if (bufferedCollisionEvents
                        .ContainsKey(cm.hash)) //if we have buffered a collision that already exists
                    {
                        bufferedCollisionEvents.Remove(cm.hash);
                    }
                }
            });
        
        

        foreach (var e in bufferedCollisionEvents)
        {
            // Console.WriteLine("SPAWNING NEW COLLISION EVENT BETWEEN " + e.Value.e1.Entity.Get<HasManagedOwner>().e.Name + " and " + e.Value.e2.Entity.Get<HasManagedOwner>().e.Name + " WITH HASH " + e.Key);
            Engine.ECSWorld.Create(
                new EventMeta(e.Value.GetType().ToString()),
                new CollisionMeta(e.Key),
                e.Value);
        }
        
        bool CollisionEventValid(ref CollisionEvent ce)
        {
            return ce.e1.IsAlive() && ce.e2.IsAlive() && !ce.e1.Entity.Has<Destroy>() && !ce.e2.Entity.Has<Destroy>();
        }
    }
}

public class EventCleaningSystem : DSystem, ICleanupSystem
{
    private QueryDescription events = new QueryDescription().WithAll<EventMeta>();
    public void Cleanup()
    {
        Engine.ECSWorld.Query(in events,
            (Arch.Core.Entity e, ref EventMeta m) =>
            {
                if (m.dirty)
                {
                    e.Add(new Destroy());
                }
                else
                {
                    m.dirty = true;
                }
            });
    }
}

public class DebugOverlaySystem : DSystem, IUpdateSystem
{
    QueryDescription colliderDebug = new QueryDescription().WithAll<Active,Collider,Position,HasManagedOwner>();
    public void Update(double dt)
    {
        Engine.ECSWorld.Query(in colliderDebug,
            (Arch.Core.Entity e, ref Position p, ref Active a, ref Collider c, ref HasManagedOwner o) =>
            {
                if(!a.active){return;}
                if(e.Id == Engine.Cursor.ECSEntity.Id){return;}
                var bounds = Utils.GetBounds(c, p);
                float minX = Single.MaxValue, minY = Single.MaxValue, maxX = 0, maxY = 0;
                foreach (var b in bounds)
                {
                    minX = b.X < minX ? b.X : minX;
                    minY = b.Y < minY ? b.Y : minY;
                    
                    maxX = b.X > maxX ? b.X : maxX;
                    maxY = b.Y > maxY ? b.Y : maxY;
                }
                //cute scaling but kind of bad without state
                // ImGUIHelper.Wrappers.SetNextWindowPosition(new(minX, minY));
                // ImGUIHelper.Wrappers.SetNextWindowSize(maxX-minX, maxY-minY);
                ImGUIHelper.Wrappers.SetNextWindowPosition(new Vector2(p.x - p.pivotX,p.y - p.pivotY));
                ImGUIHelper.Wrappers.SetNextWindowSize(100,100);
                ImGUIHelper.Wrappers.SetNextWindowBGAlpha(0f);
                ImGUIHelper.Wrappers.Begin($"e{e.Id}", 
                    ImGuiWindowFlags_.ImGuiWindowFlags_NoTitleBar | 
                    ImGuiWindowFlags_.ImGuiWindowFlags_NoMouseInputs |
                    ImGuiWindowFlags_.ImGuiWindowFlags_NoMove |
                    ImGuiWindowFlags_.ImGuiWindowFlags_NoResize |
                    ImGuiWindowFlags_.ImGuiWindowFlags_NoBringToFrontOnFocus);
                ImGUIHelper.Wrappers.Text($"{e.Id}\n{o.e.DebugText}");
                if (Engine.drawDebugColliders)
                {
                    ImGUIHelper.Wrappers.DrawQuad(bounds);
                }
                ImGUIHelper.Wrappers.End();
            });
    }
}

