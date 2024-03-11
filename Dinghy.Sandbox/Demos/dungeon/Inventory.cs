using System.Numerics;
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
    public Dictionary<int,DeckCard?> Cards = new();
    public void Init()
    {
        foreach (var c in GridCells)
        {
            c.Destroy();
        }
        GridCells.Clear();
        Cards.Clear();
        
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
                },
                OnMouseUp: (e, mods) =>
                {
                    TryUseInvItem(e.Id);
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

    public void TryUseInvItem(int entityID)
    {
        var target = GridCells.First(x => x.ECSEntity.Id == entityID);
        var index = GridCells.IndexOf(target);
        if (Cards[index] != null)
        {
            Depot.Generated.dungeon.logicTriggers.use.Emit(Systems.Logic.RootEvent, new Systems.Logic.EventData(Cards[index].ID), postExecution: move =>
            {
                RemoveFromInventory(Cards[index]);
            });
        }
    }

    public bool TryAddToInventory(DeckCard c)
    {
        var hasTargetPos = Cards.Any(x => x.Value == null);
        if (hasTargetPos)
        {
            var targetPos = Cards.First(x => x.Value == null).Key;
            Cards[targetPos] = c;
            GridCells[targetPos].DebugText = c.Name;
            return true;
        }

        return false;
    }

    public void RemoveFromInventory(DeckCard c)
    {
        var hasTargetPos = Cards.Any(x => x.Value == c);
        if (hasTargetPos)
        {
            var targetPos = Cards.First(x => x.Value == c).Key;
            Cards[targetPos] = null;
            GridCells[targetPos].DebugText = "";
        }
    }
}