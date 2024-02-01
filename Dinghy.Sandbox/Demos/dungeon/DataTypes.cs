using Arch.Core.Extensions;

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

    public readonly record struct EnemyComponent(string name);
    public class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Distance { get; set; }
        public int Attack { get; set; }
        public int XPValue { get; set; }
        public bool Aggro { get; set; }
        public bool Dead => Health <= 0;
        public Shape Entity;
        public Enemy(string name, int health, int distance, int attack, bool aggro, int xp)
        {
            Name = name;
            Health = health;
            Distance = distance;
            Attack = attack;
            Aggro = aggro;
            XPValue = xp;
            Entity = new Shape(0xFFFF0000, 32, 32)
            {
                PivotX = 16,
                PivotY = 16
            };
            Entity.ECSEntity.Add(new EnemyComponent(name));
        }

        public override string ToString()
        {
            return $"{Name} HP:{Health} DIST:{Distance} ATK:{Attack} XP:{XPValue}";
        }
    }

    public class Track(List<Slot> slots);
    public class Slot(Enemy e);
}