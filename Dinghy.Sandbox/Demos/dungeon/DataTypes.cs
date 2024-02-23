using System.Text;
using Arch.Core;
using Arch.Core.Extensions;
using Depot.Generated.dungeon;

namespace Dinghy.Sandbox.Demos.dungeon;

public class DataTypes
{
    public class Player
    {
        public int MaxHealth { get; set; } = 10;
        public int Health { get; set; } = 10;
        public int Hunger { get; set; } = 0;
        public int XP { get; private set; } = 0;
        public void GrantXP(int xp)
        {
            XP += xp;
            if (XP % 5 == 0)
            {
                Health = MaxHealth;
            }
        }

        public void Kill()
        {
            Dungeon.Death = true;
        }

        public void Move()
        {
            int moveDist = 1; //saturate this with status/buffs/etc
            Health = Health + 1 < MaxHealth ? Health + 1 : Health;
            Hunger++;
            if (Hunger > 10)
            {
                Dungeon.Player.Kill();
            }
            else
            {
                Dungeon.Track.Discard();
            }
        }

        public void Wait()
        {
            Hunger++;
            if (Hunger > 10)
            {
                Dungeon.Player.Kill();
            }
        }

        public void Attack(List<int> trackIndicies)
        {
            var attacks = Dungeon.Track.Cards
                .Where(x => trackIndicies.Contains(x.TrackPosition.Value))
                .Where(x => x.Damageable)
                .OrderBy(x => x.TrackPosition);
            foreach (var c in attacks)
            {
                c.Damage(1);
            }
        }

        public void Damage(int dmg)
        {
            Health -= dmg;
            if (Health <= 0)
            {
                Dungeon.Player.Kill();
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
        public bool IsObstacle => Data.obstacle;
        public bool CanCycleOffBOard => Data.canCycleOffBoard;
        
        
        public int Health { get; protected set; }
        public cards.cardsLine Data { get; private set; }
        public int Distance { get; set; }
        public int XPValue { get; set; }
        public int? TrackPosition { get; protected set; }
        public int? DeckPosition { get; protected set; }
        public Shape Entity;
        public Action<DeckCard> OnDestroy;

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
            Entity.ECSEntity.Add(new EnemyComponent(this));
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
            Distance = 0;
            UpdateDebugText();
        }

        public void Damage(int amt)
        {
            Health--;
            UpdateDebugText();
        }

        public void CheckForDestruction()
        {
            if (Health <= 0)
            {
                Destroy();
            }
        }

        public void Destroy()
        {
            OnDestroy?.Invoke(this);
            InputSystem.Events.Mouse.Move -= OnMouseMove;
            Entity.Destroy();
            
            Dungeon.Deck.Cards.Remove(this);
            Dungeon.Track.RemoveCard(this);
            Dungeon.Player.GrantXP(XPValue);
        }

        private void OnMouseMove(float arg1, float arg2, float arg3, float arg4, List<Modifiers> arg5)
        {
            // if (mouseDown)
            // {
            //     Quick.MoveToMouse(Entity);
            // }
        }

        void MousePressed(List<Modifiers> m)
        {
            if (Damageable)
            {
                Events.Commands.Execute?.Invoke(new PlayerAttackTrackCards([TrackPosition.Value]));
            }
        }

        void MouseOver(List<Modifiers> mods)
        {
            Entity.Color = HoveredColor;
        }
        void MouseLeave(List<Modifiers> mods)
        {
            Entity.Color = BaseColor;
        }

        public void Act()
        {
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
}