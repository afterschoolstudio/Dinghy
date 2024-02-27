using System.Text;
using Arch.Core;
using Arch.Core.Extensions;
using Depot.Generated.dungeon;

namespace Dinghy.Sandbox.Demos.dungeon;

public class DeckCard
{
    public int ID { get; protected set; }
    public string Name { get; protected set; }
    public int MaxHealth => Data.health;
    public int Attack => Data.damage;
    public bool Damageable => Data.damageable;
    public List<Keyword> Keywords = new();
    // public bool IsObstacle => Data.obstacle;
    // public int XPValue => Data.XPValue;


    private int health;

    public int Health
    {
        get => health;
        set
        {
            health = value;
            UpdateDebugText();
        }
    }
    public cards.cardsLine Data { get; private set; }
    public int distance;

    public int Distance
    {
        get => distance;
        set
        {
            distance = value;
            UpdateDebugText();
        }
    }
    public Shape Entity;

    public Color HoveredColor = new Color(1.0f, 0.1f, 0.1f, 0.1f);
    public Color BaseColor = new Color(1.0f, 0.01f, 0.01f, 0.01f);
    public DeckCard(int cardID, string name, cards.cardsLine Data)
    {
        Entity = new Shape(BaseColor, 150, 450,OnMouseOver:MouseOver,OnMouseLeave:MouseLeave,OnMousePressed:MousePressed)
        {
            PivotX = 74,
            PivotY = 225,
            ColliderActive = true,
            Active = false
        };
        
        if (Data.keywords != null)
        {
            foreach (var t in Data.keywords)
            {
                Keywords.Add(Dungeon.GameLogic.Keywords.First(x => x.GUID == t.keyword.GUID));
            }
        }
        
        ID = cardID;
        Name = name;
        this.Data = Data;
        Health = MaxHealth;
        UpdateDebugText();
    }

    void UpdateDebugText()
    {
        var sb = new StringBuilder();
        sb.AppendLine(Name);
        sb.AppendLine($"{Health}/{MaxHealth}");
        sb.AppendLine($"d:{Distance}");
        foreach (var k in Keywords)
        {
            sb.AppendLine($"{k.Name}");
            foreach (var t in k.Triggers)
            {
                sb.AppendLine($"    {t.Name}");
            }
        }
        // if (IsObstacle)
        // {
        //     sb.AppendLine("obstacle");
        // }
        Entity.DebugText = sb.ToString();
    }

    public void DestroyCardEntity()
    {
        Entity.Destroy();
    }

    void MousePressed(Arch.Core.Entity e, List<Modifiers> m)
    {
        if(Dungeon.Player.Dead){return;}
        if (Damageable)
        {
            Events.Commands.Execute?.Invoke(new PlayerInputCommands.Attack(this));
        }
    }

    void MouseOver(Arch.Core.Entity e, List<Modifiers> mods)
    {
        if(Dungeon.Player.Dead){return;}
        Entity.Color = HoveredColor;
    }
    void MouseLeave(Arch.Core.Entity e, List<Modifiers> mods)
    {
        if(Dungeon.Player.Dead){return;}
        Entity.Color = BaseColor;
    }
}