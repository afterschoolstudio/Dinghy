﻿using Arch.Core;
using Volatile;

namespace Dinghy;

public static class Quick
{
    public static Random Random = new System.Random();
    public static int RandInt() => Random.Next();
    public static float RandFloat() => Random.NextSingle();
    public static double RandDouble() => Random.NextDouble();
    
    public static double Map(double value, double fromSource, double toSource, double fromTarget, double toTarget)
    {
        return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
    }
    
    public static float MapF(float value, float fromSource, float toSource, float fromTarget, float toTarget)
    {
        return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
    }

    public static void MoveToMouse(Entity e)
    {
        e.X = (int)InputSystem.MouseX;
        e.Y = (int)InputSystem.MouseY;
    }

    public static Vector2 RandUnitCircle()
    {
        var radian = RandDouble() * Math.PI * 2;
        return new Vector2(
            (float)Math.Cos(radian),
            (float)Math.Sin(radian));
    }
    public static List<Frame> HorizontalFrameSequence(int startX, int startY, int frameWidth, int frameHeight, int frameCount)
    {
        List<Frame> frames = new List<Frame>();
        for (int i = 0; i < frameCount; i++)
        {
            frames.Add(new Frame(startX + i * frameWidth, startY, frameWidth, frameHeight));
        }

        return frames;
    }

    public static Action Update
    {
        get => Engine.Update;
        set => Engine.Update += value;
    }
    
    public static Action Setup
    {
        get => Engine.Setup;
        set => Engine.Setup += value;
    }
    public static Action<Key,List<Modifiers>> OnKeyDown
    {
        get => InputSystem.Events.Key.Down;
        set => InputSystem.Events.Key.Down += value;
    }
    
    public static Action<Key,List<Modifiers>> OnKeyPressed
    {
        get => InputSystem.Events.Key.Pressed;
        set => InputSystem.Events.Key.Pressed += value;
    }
    
    public static Action<Key,List<Modifiers>> OnKeyUp
    {
        get => InputSystem.Events.Key.Up;
        set => InputSystem.Events.Key.Up += value;
    }
}
