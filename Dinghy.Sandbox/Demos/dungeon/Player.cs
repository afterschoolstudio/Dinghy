namespace Dinghy.Sandbox.Demos.dungeon;

public class Player
{
    public int MaxHealth { get; set; } = 10;
    public int Health { get; set; } = 10;
    public int Hunger { get; set; } = 0;
    public int XP { get; private set; } = 0;
    public int MovedDistance { get; private set; } = 0;
    public bool Dead { get; protected set; }

    public void Init()
    {
        Health = MaxHealth;
        Hunger = 0;
        XP = 0;
        MovedDistance = 0;
        Dead = false;
    }
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
        Dead = true;
    }

    public void Move()
    {
        int moveDist = 1; //saturate this with status/buffs/etc
        Dungeon.Track.IncreaseCardDistances(moveDist);
        MovedDistance += moveDist;
        // Health = Health + 1 < MaxHealth ? Health + 1 : Health; moving this to keyword
        Hunger++;
        if (Hunger > 10)
        {
            Dungeon.Player.Kill();
        }
        else
        {
            Dungeon.Track.Cycle();
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

    public void Damage(int dmg)
    {
        if(Dungeon.ActiveDebugOptions.Invincible){return;}
        Health -= dmg;
        if (Health <= 0)
        {
            Dungeon.Player.Kill();
        }
    }
}