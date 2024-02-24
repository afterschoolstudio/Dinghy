using System.Text;
using Arch.Core;
using Arch.Core.Extensions;
using Depot.Generated.dungeon;

namespace Dinghy.Sandbox.Demos.dungeon;

public class DeckCard
{
    public string Name { get; protected set; }
    public int MaxHealth => Data.health;
    public int Attack => Data.damage;
    public bool Damageable => Data.damageable;
    public bool IsObstacle => Data.obstacle;
    public bool CanCycleOffBOard => Data.canCycleOffBoard;
    
    
    public int Health { get; protected set; }
    public cards.cardsLine Data { get; private set; }
    public int Distance { get; set; }
    public int XPValue { get; set; }
    public int? TrackPosition { get; protected set; }
    public int? DeckPosition { get; protected set; }
    public Shape Entity;

    public Color HoveredColor = new Color(1.0f, 0.1f, 0.1f, 0.1f);
    public Color BaseColor = new Color(1.0f, 0.01f, 0.01f, 0.01f);
    public DeckCard(string id, cards.cardsLine Data, int xp)
    {
        Name = id;
        this.Data = Data;
        Health = MaxHealth;
        XPValue = xp;
        Entity = new Shape(BaseColor, 150, 450,OnMouseOver:MouseOver,OnMouseLeave:MouseLeave,OnMousePressed:MousePressed)
        {
            PivotX = 74,
            PivotY = 225,
            ColliderActive = true,
            Active = false
        };
        UpdateDebugText();
        InputSystem.Events.Mouse.Move += OnMouseMove;
    }

    void UpdateDebugText()
    {
        var sb = new StringBuilder();
        sb.AppendLine(Name);
        sb.AppendLine($"{Health}/{MaxHealth}");
        sb.AppendLine($"p:{TrackPosition}");
        sb.AppendLine($"d:{Distance}");
        if (IsObstacle)
        {
            sb.AppendLine("obstacle");
        }
        Entity.DebugText = sb.ToString();
    }

    public void SetDeckPosition(int? pos) => DeckPosition = pos;

    public void SetTrackPosition(int? pos)
    {
        TrackPosition = pos;
        Entity.Active = TrackPosition.HasValue;
        UpdateDebugText();
    }

    public void SetDistance(int distance)
    {
        Distance = distance;
        UpdateDebugText();
    }

    public void Damage(int amt)
    {
        if (!Dungeon.ActiveDebugOptions.DontDamageEnemies)
        {
            Health--;
        }
        // Entity.ECSEntity.Add(new Systems.Shake
        // {
        //     Multiplier = Dungeon.Shake.Multiplier,
        //     BaseShake = Dungeon.Shake.BaseShake,
        //     Tick = Dungeon.Shake.Tick,
        //     Decay = Dungeon.Shake.Decay,
        //     DeathTime = Dungeon.Shake.DeathTime
        // });

        Entity.ECSEntity.Add(new Systems.Shake());
        if (Health <= 0)
        {
            Destroy();
            return;
        }
        UpdateDebugText();
    }

    public void Destroy()
    {
        Dungeon.Deck.Cards.Remove(this);
        Dungeon.Player.GrantXP(XPValue);
        Dungeon.Track.Discard(this,false);
        
        InputSystem.Events.Mouse.Move -= OnMouseMove;
        Entity.Destroy();
    }

    private void OnMouseMove(float arg1, float arg2, float arg3, float arg4, List<Modifiers> arg5)
    {
        // if (mouseDown)
        // {
        //     Quick.MoveToMouse(Entity);
        // }
    }

    void MousePressed(Arch.Core.Entity e, List<Modifiers> m)
    {
        if (Damageable)
        {
            Events.Commands.Execute?.Invoke(new PlayerAttackTrackCards([TrackPosition.Value]));
        }
    }

    void MouseOver(Arch.Core.Entity e, List<Modifiers> mods)
    {
        Entity.Color = HoveredColor;
    }
    void MouseLeave(Arch.Core.Entity e, List<Modifiers> mods)
    {
        Entity.Color = BaseColor;
    }

    public void Act()
    {
        //NEED TO MAKE THIS DISTINGUISH BETWEEN ACTING DIRECTLY AND CHASING (FROM MOVEMENT)
        //MAYBE AN INTERFACE DIFFERENCE?
        
        //try to attack if in range
        if (Distance <= 1)
        {
            Dungeon.Player.Damage(Attack);
        }
        else
        {
            Distance -= 1;
        }
        UpdateDebugText();
    }

    public override string ToString()
    {
        return $"{Name} HP:{Health} DIST:{Distance} ATK:{Attack} XP:{XPValue}";
    }
}