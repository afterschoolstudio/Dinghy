using System.Linq;
using Dinghy.Core;
using Dinghy.Internal.Sokol;
using static Dinghy.Sandbox.Demos.dungeon.DataTypes;
using static Dinghy.Core.ImGUI.ImGUIHelper.Wrappers;

namespace Dinghy.Sandbox.Demos.dungeon;

[DemoScene("dungeon")]
public class Dungeon : Scene
{
    Player player = new ();
    private List<Enemy> Enemies = new ();
    Grid g = new (new (new(Engine.Width / 2f, Engine.Height / 2f), new(0.5f, 0.5f), 50, 50, new(0.5f, 0.5f), 10, 10));
    private Shape pointer;
    public override void Create()
    {
        Systems.Init();
        pointer = new Shape(0x000000,1,1){Name = "pointer",ColliderActive = true};
        for (int i = 0; i < 10; i++)
        {
            var health = (int)(Quick.RandFloat() * 5) + 1;
            var atk = (int)(Quick.RandFloat() * 3) + 1;
            var xp = (int)(health * atk / 2f) + 1;
            var enemy = new Enemy(i.ToString(), health, i % 4, atk, i < 3, xp);
            enemy.Entity.ColliderActive = true;
            g.ApplyPositionToEntity(i*2,enemy.Entity);
            Enemies.Add(enemy);
        }
    }

    private ImVec2 buttonSize = new () { x = 100, y = 20 };
    public override void Update(double dt)
    {
        Quick.MoveToMouse(pointer);
        Begin("game",ImGuiWindowFlags_.ImGuiWindowFlags_NoTitleBar);
        bool acted = false;
        foreach (var e in Enemies.Where(x => x.Aggro && !x.Dead))
        {
            Text(e.ToString());
            if (Button($"Attack{e.Name}",buttonSize))
            {
                e.Health--;
                acted = true;
                if (e.Health <= 0)
                {
                    player.GrantXP(e.XPValue);
                }
                Events.Raise(new Events.ButtonClicked());
            }
        }
        Text($"Player HP:{player.Health} XP:{player.XP}");
        if (Button($"Move Player",buttonSize))
        {
            acted = true;
        }
        
        Text("Non Aggro: " + Enemies.Where(x => !x.Aggro).Count());
        End();

        if (acted)
        {
            foreach (var e in Enemies.Where(x => x.Aggro && !x.Dead && x.Distance == 0))
            {
                player.Health -= e.Attack;
            }
            
            foreach (var e in Enemies.Where(x => x.Aggro && !x.Dead && x.Distance > 0))
            { 
                e.Distance--;
            }

            if (Quick.RandFloat() > 0.7f)
            {
                var candidate = Enemies.Where(x => !x.Aggro && !x.Dead).FirstOrDefault();
                if (candidate != null)
                {
                    candidate.Aggro = true;
                }
            }
        }
    }
}