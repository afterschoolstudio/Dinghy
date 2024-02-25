﻿using System.Numerics;
using Arch.Core.Extensions;
using Dinghy.Core;

namespace Dinghy.Sandbox.Demos.dungeon;

public class Inventory
{
    public Grid Grid = new (new (
        new(Engine.Width / 2f, Engine.Height / 2f), 
        new(0.5f, 0.5f), 
        74, 74, 
        new(0.5f, 0.5f), 
        8,
        2));

    private List<Shape> GridCells = new List<Shape>();
    public void Init()
    {
        foreach (var c in GridCells)
        {
            c.Destroy();
        }
        GridCells.Clear();
        
        Grid.TransformGrid(0f,1f,1f,new Vector2(0,350f));
        foreach (var pos in Grid.Points)
        {
            GridCells.Add(
            new Shape(Palettes.ENDESGA[3],64,64,
                OnMouseEnter: (e, mods) =>
                {
                    e.Get<ShapeRenderer>().Color = Palettes.ENDESGA[4];
                },
                OnMouseLeave: (e,mods) =>
                {
                    e.Get<ShapeRenderer>().Color = Palettes.ENDESGA[3];
                })
            {
                PivotX = 32,
                PivotY = 32,
                X = pos.X,
                Y = pos.Y,
                ColliderActive = true
            });
        }
    }
}