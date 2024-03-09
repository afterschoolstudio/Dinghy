using System.Numerics;
using Arch.Core.Extensions;
using Dinghy.Core;

namespace Dinghy.Sandbox.Demos.dungeon;

public class Equipment
{
    public Grid Grid = new (new (
        new(Engine.Width / 2f, Engine.Height / 2f), 
        new(0.5f, 0.5f), 
        74, 74, 
        new(0.5f, 0.5f), 
        5,
        1));

    private List<Shape> GridCells = new List<Shape>();
    public Dictionary<int,DeckCard?> Cards = new();
    public void Init()
    {
        foreach (var c in GridCells)
        {
            c.Destroy();
        }
        GridCells.Clear();
        Cards.Clear();
        
        Grid.TransformGrid(0f,1f,1f,new Vector2(0,225f));
        foreach (var pos in Grid.Points)
        {
            GridCells.Add(
            new Shape(Palettes.ENDESGA[6],64,64,
                OnMouseEnter: (e, mods) =>
                {
                    e.Get<ShapeRenderer>().Color = Palettes.ENDESGA[7];
                },
                OnMouseLeave: (e,mods) =>
                {
                    e.Get<ShapeRenderer>().Color = Palettes.ENDESGA[6];
                })
            {
                PivotX = 32,
                PivotY = 32,
                X = pos.X,
                Y = pos.Y,
                ColliderActive = true
            });
        }
        
        for (int i = 0; i < GridCells.Count; i++)
        {
            Cards.Add(i,null); 
        }
    }
}