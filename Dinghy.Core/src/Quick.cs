﻿using Arch.Core;

namespace Dinghy;

public static class Quick
{
    public static Random Random = new System.Random();
    public static int RandInt() => Random.Next();
    public static float RandFloat() => Random.NextSingle();
    public record SpriteData(string texture,int startX = 0, int startY = 0) : EntityData
    {
        public override void GetEntity(out Entity e)
        {
            e = Engine.World.Create(
                new Position(startX, startY), 
                new SpriteRenderer(texture));
        }
    }

    public static Entity Add(EntityData d)
    {
        d.GetEntity(out var e);
        Engine.World.Add<Entity>(e);
        return e;
    }
    
    public static Action<Key> OnKeyDown
    {
        get => InputSystem.Events.Key.Down;
        set => InputSystem.Events.Key.Down += value;
    }
    
    public static Action<Key> OnKeyPressed
    {
        get => InputSystem.Events.Key.Pressed;
        set => InputSystem.Events.Key.Pressed += value;
    }
    
    public static Action<Key> OnKeyUp
    {
        get => InputSystem.Events.Key.Up;
        set => InputSystem.Events.Key.Up += value;
    }
}