using System.Text;
using Arch.Core;
using Arch.Core.Extensions;
using Depot.Generated.dungeon;

namespace Dinghy.Sandbox.Demos.dungeon;

public class DataTypes
{
    // public record struct Player(int MaxHealth = 10, int Health = 10, int XP = 0);
    public class Player
    {
        public int MaxHealth { get; set; } = 10;
        public int Health { get; set; } = 10;
        public int XP { get; private set; } = 0;
        public void GrantXP(int xp)
        {
            XP += xp;
            if (XP % 5 == 0)
            {
                Health = MaxHealth;
            }
        }
    }

    public readonly record struct EnemyComponent(DeckCard DeckCard);
    public class DeckCard
    {
        public string Name { get; protected set; }
        public int MaxHealth => Data.health;
        public int Attack => Data.damage;
        public bool Damageable => Data.damageable;
        public int Health { get; protected set; }
        public cards.cardsLine Data { get; private set; }
        public int? Distance { get; set; } = null;
        public int XPValue { get; set; }
        public int? TrackPosition { get; protected set; }
        public int? DeckPosition { get; protected set; }
        public Shape Entity;
        public Action<DeckCard> OnDestroy;
        public DeckCard(string id, cards.cardsLine Data, int xp)
        {
            Name = id;
            this.Data = Data;
            Health = MaxHealth;
            XPValue = xp;
            Entity = new Shape(0xFFFF0000, 32, 32,collisionStart:CollisionStart,collisionStop:CollisionStop,OnMousePressed:MousePressed, OnMouseUp:MouseUp)
            {
                PivotX = 16,
                PivotY = 16,
                ColliderActive = true,
                Active = false
            };
            UpdateDebugText();
            Entity.ECSEntity.Add(new EnemyComponent(this));
            InputSystem.Events.Mouse.Move += OnMouseMove;
        }

        void UpdateDebugText()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Name);
            sb.AppendLine($"TrackPos: {TrackPosition}");
            Entity.DebugText = sb.ToString();
        }

        public void SetDeckPosition(int? pos) => DeckPosition = pos;

        public void SetTrackPosition(int? pos)
        {
            TrackPosition = pos;
            if (TrackPosition.HasValue)
            {
                Entity.Active = true;
            }
            UpdateDebugText();
        }

        private void MouseUp(List<Modifiers> obj)
        {
            mouseDown = false;
        }

        public void Destroy()
        {
            OnDestroy?.Invoke(this);
            InputSystem.Events.Mouse.Move -= OnMouseMove;
            Console.WriteLine("marking entity for destroy");
            Entity.Destroy();
            Console.WriteLine("post marking entity for destroy");
        }

        private void OnMouseMove(float arg1, float arg2, float arg3, float arg4, List<Modifiers> arg5)
        {
            if (mouseDown)
            {
                Quick.MoveToMouse(Entity);
            }
        }

        private bool mouseDown = false;
        void MousePressed(List<Modifiers> m)
        {
            Console.WriteLine(Name + " mouse down");
            Console.WriteLine($"{Name} took damage");
            Health--;
            if (Health <= 0)
            {
                Destroy();
            }
            mouseDown = true;
        }

        void CollisionStart(EntityReference self, EntityReference other)
        {
            Entity.Color = 0xFF00FF00;
        }
        void CollisionStop(EntityReference self, EntityReference other)
        {
            Entity.Color = 0xFFFF0000;
        }

        public override string ToString()
        {
            return $"{Name} HP:{Health} DIST:{Distance} ATK:{Attack} XP:{XPValue}";
        }
    }

    public class Track(List<Slot> slots);
    public class Slot(DeckCard e);
}