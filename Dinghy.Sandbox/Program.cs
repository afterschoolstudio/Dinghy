using System.Diagnostics;
using Arch.Core.Extensions;
using Dinghy;
using Volatile;
using static Dinghy.Quick;

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
physics();

Engine.Run(new Engine.RunOptions(width,height,"dinghy"));

void texture()
{
	SpriteData fullConscript = new(conscriptImage);
	new Sprite(fullConscript);
}

void textureFrame()
{
	SpriteData conscriptFrame0 = new(conscriptImage, new Frame(0,0,64,64));
	new Sprite(conscriptFrame0);
}

void animation()
{
	AnimatedSpriteData animatedConscript = new AnimatedSpriteData(
		conscriptImage,
		new() { new("test", HorizontalFrameSequence(0, 0, 64, 64, 4),
			0.4f) });
	new AnimatedSprite(animatedConscript);
}

void simpleUpdate()
{
	SpriteData conscriptFrame0 = new(conscriptImage, new Frame(0,0,64,64));
	var e = new Sprite(conscriptFrame0);
	Update += () =>
	{
		e.X = 0 + (int)MathF.Abs((MathF.Sin((float)Engine.Time) * 100));
	};
}

void interaction()
{
	AnimatedSpriteData animatedConscript = new AnimatedSpriteData(
		conscriptImage,
		new() { new("test", HorizontalFrameSequence(0, 0, 64, 64, 4),
			0.4f) });
	var e = new AnimatedSprite(animatedConscript);
	
	OnKeyDown += (key) =>  {
		(float dx, float dy) v = key switch {
			Key.LEFT => (-1f, 0),
			Key.RIGHT => (1f, 0),
			Key.UP => (0, -1f),
			Key.DOWN => (0, 1f),
			_ => (0, 0)
		};
		e.DX += v.dx;
		e.DY += v.dy;
	};
}

void bunny()
{
	SpriteData logo = new(logoImage);
	int bunnies = 10000;
	TestBunny b = null;
	for (int i = 0; i < bunnies; i++)
	{
		b = new TestBunny(logo);
		b.SetVelocity(RandFloat() * 10,RandFloat()*10-5);
	}

	Engine.DebugTextStr = $"{bunnies} buns";
	int addedbuns = 1000;
	OnKeyDown += (key) =>  {
		if (key == Key.SPACE)
		{
			for (int i = 0; i < addedbuns; i++)
			{
				b = new TestBunny(logo);
				b.SetVelocity(RandFloat() * 10,RandFloat()*10-5);
			}
			bunnies += addedbuns;
			Engine.DebugTextStr = $"{bunnies} buns";
		}
	};
}

void asteroidsGame()
{
	SpriteData logo = new(logoImage);
	SpriteData conscript = new(conscriptImage, new Frame(0,0,64,64));
	var player = new Sprite(logo){Name = "player"};
	double bulletCooldown = 0;
	OnKeyDown += (key) =>  {
		(float dx, float dy) v = key switch {
			Key.LEFT => (-1f, 0),
			Key.RIGHT => (1f, 0),
			Key.UP => (0, -1f),
			Key.DOWN => (0, 1f),
			_ => (0, 0)
		};
		player.SetVelocity(player.DX + v.dx, player.DY + v.dy);

		if (key == Key.SPACE && bulletCooldown > 1)
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

void physics()
{
	SpriteData conscript = new(conscriptImage, new Frame(0,0,64,64));
	double timer = 0;
	VoltConfig.AreaMassRatio = 0.000007f;
	Dictionary<Sprite, VoltBody> bods = new Dictionary<Sprite, VoltBody>();
	var bot = new Vector2(0, height / 2f);
	Setup += () =>
	{
		var poly = Engine.PhysicsWorld.CreatePolygonWorldSpace(
			new Vector2[]
			{
				new Vector2(0, height),
				new Vector2(width, height),
				new Vector2(width, height + 100),
				new Vector2(0, height + 100)
			}, 0f);
		var bod = Engine.PhysicsWorld.CreateStaticBody(bot, 0f, new[] { poly });
		bod.Set(bot,0f);
		Console.WriteLine(bod.IsStatic);
		Console.WriteLine($"{bod.Position.x},{bod.Position.y}");
	};
	
	Update += () =>
	{
		//spawn physics
		timer += Engine.DeltaTime;
		if (timer > 0.1)
		{
			// var a = new Sprite(conscript) {
			// 	Y = 0,
			// 	X = (int)((Engine.Width / 2f) + MathF.Sin(RandFloat() * 2 - 1) * Engine.Width / 2.5f)
			// };
			// var startPos = new Vector2(Engine.Width / 2f, Engine.Height / 2f);
			var startPos = new Vector2(InputSystem.MouseX, InputSystem.MouseY);
			var a = new Sprite(conscript) {
				X = (int)startPos.x,
				Y = (int)startPos.y
			};
			var poly = Engine.PhysicsWorld.CreatePolygonWorldSpace(
				new Vector2[]
				{
					new Vector2(startPos.x, startPos.y),
					new Vector2(startPos.x + 64, startPos.y),
					new Vector2(startPos.x + 64, startPos.y + 64),
					new Vector2(startPos.x, startPos.y + 64)
				},-1f);
			var bod = Engine.PhysicsWorld.CreateDynamicBody(startPos, 0f, new []{poly});
			bods.Add(a,bod);
			// bod.AddForce(new Vector2(0,9.8f));
			// a.SetVelocity(-2,0);
			timer = 0;
		}

		foreach (var b in bods)
		{
			b.Value.AddForce(new Vector2(0,9.8f));
			Console.WriteLine($"{b.Key.ECSEntity.Id} {(int)b.Value.Position.x},{(int)b.Value.Position.y}");
			b.Key.SetPosition((int)b.Value.Position.x,(int)b.Value.Position.y);
			// transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Rad2Deg * this.body.Angle);
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