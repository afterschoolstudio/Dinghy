using System.Diagnostics;
using Arch.Core.Extensions;
using Dinghy;
using Dinghy.Collision;
using Dinghy.Core;
using Dinghy.Core.ImGUI;
using Dinghy.Sandbox.Demos;
using Volatile;
using static Dinghy.Quick;
using Utils = Dinghy.Collision.Utils;

var width = 500;
var height = 500;
var conscriptImage = new TextureData("conscript.png");
var logoImage = new TextureData("logo.png");

// texture();
// textureFrame();
// animation();
// simpleUpdate();
// interaction();
// bunny();
// asteroidsGame();
// physics();
// shape();
// physicsShape();
// entityEmitter();
// collision();
// grid();
// particleSystem();

OnKeyDown += (key,_) =>  {
	if (key == Key.C)
	{
		Engine.Clear = !Engine.Clear;
	}
};

List<DemoSceneInfo> demoTypes = new();
Engine.Run(new Engine.RunOptions(width,height,"dinghy", 
	() =>
	{
		demoTypes = Util.GetDemoSceneTypes().ToList();
	}, 
	() =>
	{
		drawDemoOptions();
	}
	));

void drawDemoOptions()
{
	ImGUIHelper.Wrappers.BeginMainMenuBar();
	if (ImGUIHelper.Wrappers.BeginMenu("Dinghy"))
	{
		if (ImGUIHelper.Wrappers.BeginMenu("Demos"))
		{
			Scene? scene = null;
			
			foreach (var type in demoTypes)
			{
				if(ImGUIHelper.Wrappers.MenuItem(type.Name))
				{
					scene = Util.CreateInstance(type.Type) as Scene;
					scene.Name = type.Name;
				}
			}
			if (scene != null)
			{
				Engine.TargetScene.Unmount(() =>
				{
					scene.Mount(0);
					scene.Load(scene.Start);
				});
			}
			ImGUIHelper.Wrappers.EndMenu();
		}
		ImGUIHelper.Wrappers.EndMenu();
	}
	ImGUIHelper.Wrappers.EndMainMenuBar();

}

void asteroidsGame()
{
	SpriteData logo = new(logoImage);
	SpriteData conscript = new(conscriptImage, new Frame(0,0,64,64));
	var player = new Sprite(logo){Name = "player"};
	double bulletCooldown = 0;
	OnKeyDown += (key,_) =>  {
		(float dx, float dy) v = key switch {
			Key.LEFT => (-1f, 0),
			Key.RIGHT => (1f, 0),
			Key.UP => (0, -1f),
			Key.DOWN => (0, 1f),
			_ => (0, 0)
		};
		player.SetVelocity(player.DX + v.dx, player.DY + v.dy);

		if (key == Key.SPACE)
		{
			//spawn bullets
			var a = new Sprite(conscript) {
				X = player.X, 
				Y = player.Y
			};
			a.SetVelocity(2.5f,0);
			bulletCooldown = 0f;
		}
	};

	double timer = 0;
	Update += () =>
	{
		//spawn asteroids
		timer += Engine.DeltaTime;
		bulletCooldown += Engine.DeltaTime;
		if (timer > 2)
		{
			var a = new Sprite(conscript) {
				X = Engine.Width, 
				Y = (int)((Engine.Height / 2f) + MathF.Sin(RandFloat() * 2 - 1) * Engine.Height / 2.5f)
			};
			a.SetVelocity(-2,0);
			timer = 0;
		}
	};
}

/*
add(sprite with tex = res.ship)
add(new sprite(res.ship))



```c#

Engine.Update += (() => {

foreach (var bullet in bullets) {

var status = bullet.Get<Collider>().Status;

if(status.colliding && status.object is not Ship) {

Destroy(bullet,status.object);

}

if(bullet.X > Screen.Width) {

Destroy(bullet);

}

}

  

foreach (var asteroid in asteroids) {

if(asteroid.X < 0) {

Destroy(asteroid);

}

}

  

if(asteroids.Count <= 5) {

for (int i = 0; i < 10-asteroids.Count; i++) {

asteroids.Add(new Asteroid(

Screen.Width / 2 + Random(0,Screen.Width),

Random(0,Screen.Height),

true));

}

}

}

kdl also maybe
objects can be constructed manually, or you can get something like prefabs from script defines like this

bullet.eno
# Bullet << Object2D
X: 10
Y: 50
## Components:
- Sprite
- Collider
- Mover
### Sprite:
img = bullet.png
### Mover:
X = 1;


asteroid.eno
# Bullet << Object2D
X: 10
Y: 50
## Components:
- Sprite
- Collider
- Mover
### Sprite:
img = bullet.png
### Mover:
X = 1;


ship.eno
# Ship << Object2D
X: 50
Y: Screen.Height / 2
## Components:
- Sprite
- Collider
- Mover
### Sprite:
img = ship.png
*/