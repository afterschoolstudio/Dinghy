namespace Dinghy.Sandbox.Demos.dungeon;

public class Player
{
    public int MaxHealth { get; set; } = 10;
    public int Health { get; set; } = 10;
    public int Hunger { get; set; } = 0;
    public int XP { get; private set; } = 0;
    public int MovedDistance { get; private set; } = 0;
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
        Dungeon.Track.IncreaseCardDistances(moveDist);
        MovedDistance += moveDist;
        Health = Health + 1 < MaxHealth ? Health + 1 : Health;
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
        if(Dungeon.ActiveDebugOptions.Invincible){return;}
        Health -= dmg;
        if (Health <= 0)
        {
            Dungeon.Player.Kill();
        }
    }
}