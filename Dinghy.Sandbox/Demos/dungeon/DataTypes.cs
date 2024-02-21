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

        public Action<PlayerAction> PlayerTookAction;
        public void Act(PlayerAction p)
        {
            PlayerTookAction?.Invoke(p);
        }

        public record PlayerAction(string ActionType);

        public void Move()
        {
            Health = Health + 1 < MaxHealth ? Health + 1 : Health;
            Hunger++;
            if (Hunger > 10)
            {
                PlayerTookAction?.Invoke(DiedAction);
            }
            else
            {
                PlayerTookAction?.Invoke(MoveAction);
            }
        }

        public void Wait()
        {
            if (Hunger > 10)
            {
                PlayerTookAction?.Invoke(DiedAction);
            }
            else
            {
                PlayerTookAction?.Invoke(WaitAction);
            }
        }

        public void AttackPlayer(int dmg)
        {
            Health -= dmg;
            if (Health <= 0)
            {
                PlayerTookAction?.Invoke(DiedAction);
            }
        }
        public PlayerAction MoveAction => new ("Move");
        public PlayerAction WaitAction => new ("Wait");
        public PlayerAction DiedAction => new ("Death");
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
            Entity = new Shape(BaseColor, 50, 150,OnMouseOver:MouseOver,OnMouseLeave:MouseLeave,OnMousePressed:MousePressed, OnMouseUp:MouseUp)
            {
                PivotX = 25,
                PivotY = 75,
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
            sb.AppendLine($"p:{TrackPosition}");
            sb.AppendLine($"d:{Distance}");
            sb.AppendLine($"obs:{IsObstacle}");
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

        private void MouseUp(List<Modifiers> obj)
        {
            // mouseDown = false;
        }

        public void Destroy()
        {
            OnDestroy?.Invoke(this);
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

        // private bool mouseDown = false;
        void MousePressed(List<Modifiers> m)
        {
            Console.WriteLine(Name + " mouse down");
            Console.WriteLine($"{Name} took damage");
            Health--;
            if (Health <= 0)
            {
                Destroy();
            }
            // mouseDown = true;
        }

        void MouseOver(List<Modifiers> mods)
        {
            Entity.Color = HoveredColor;
        }
        void MouseLeave(List<Modifiers> mods)
        {
            Entity.Color = BaseColor;
        }

        public override string ToString()
        {
            return $"{Name} HP:{Health} DIST:{Distance} ATK:{Attack} XP:{XPValue}";
        }
    }
}