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

Engine.Run(new Engine.RunOptions(width,height,"dinghy", 
	() =>
	{
		// animation();
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
			if(ImGUIHelper.Wrappers.MenuItem("01 Texture"))
			{
				scene = new Texture() { Name = "Texture Scene" };
			}
			if(ImGUIHelper.Wrappers.MenuItem("02 Texture Frame"))
			{
				scene = new TextureFrame() { Name = "Texture Frame Scene" };
			}
			if(ImGUIHelper.Wrappers.MenuItem("03 Animation"))
			{
				scene = new Animation() { Name = "Animation Scene" };
			}
			if(ImGUIHelper.Wrappers.MenuItem("04 Simple Update"))
			{
				scene = new SimpleUpdate() { Name = "Simple Update Scene" };
			}
			if(ImGUIHelper.Wrappers.MenuItem("Particle System"))
			{
				scene = new ParticleSystem() { Name = "Particle System Scene" };
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

void interaction()
{
	AnimatedSpriteData animatedConscript = new AnimatedSpriteData(
		conscriptImage,
		new() { new("test", HorizontalFrameSequence(0, 0, 64, 64, 4),
			0.4f) });
	var e = new AnimatedSprite(animatedConscript);
	
	OnKeyDown += (key,_) =>  {
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
	OnKeyDown += (key,mods) =>  {
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
				new Vector2(0, height + 100),
				new Vector2(width, height + 100),
				new Vector2(width, height)
			}, 0f);
		var bod = Engine.PhysicsWorld.CreateStaticBody(bot, 0f, new[] { poly });
		bod.Set(bot,0f);
		// Console.WriteLine(bod.IsStatic);
		// Console.WriteLine($"{bod.Position.x},{bod.Position.y}");
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
					new Vector2(startPos.x, startPos.y + 64),
					new Vector2(startPos.x + 64, startPos.y + 64),
					new Vector2(startPos.x + 64, startPos.y)
				},1f);
			var bod = Engine.PhysicsWorld.CreateDynamicBody(startPos, 0f, new []{poly});
			bods.Add(a,bod);
			// bod.AddForce(new Vector2(0,9.8f));
			// a.SetVelocity(-2,0);
			timer = 0;
		}

		foreach (var b in bods)
		{
			b.Value.AddForce(new Vector2(0,9.8f));
			// Console.WriteLine($"{b.Key.ECSEntity.Id} {(int)b.Value.Position.x},{(int)b.Value.Position.y}");
			b.Key.SetPosition((int)b.Value.Position.x,(int)b.Value.Position.y,b.Value.Angle,b.Key.ScaleX,b.Key.ScaleY);
			// transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Rad2Deg * this.body.Angle);
		}
	};
	
}

void shape()
{
	new Shape(new Color(Palettes.ENDESGA[9]));
}

void physicsShape()
{
	double timer = 0;
	VoltConfig.AreaMassRatio = 0.000007f;
	Dictionary<Shape, VoltBody> bods = new Dictionary<Shape, VoltBody>();
	var bot = new Vector2(0, height / 2f);
	Setup += () =>
	{
		var poly = Engine.PhysicsWorld.CreatePolygonWorldSpace(
			new Vector2[]
			{
				new Vector2(0, height),
				new Vector2(0, height + 100),
				new Vector2(width, height + 100),
				new Vector2(width, height)
			}, 0f);
		var bod = Engine.PhysicsWorld.CreateStaticBody(bot, 0f, new[] { poly });
		bod.Set(bot,0f);
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
			var a = new Shape(new Color(Palettes.ENDESGA[Quick.Random.Next(Palettes.ENDESGA.Count)])) {
				X = (int)startPos.x,
				Y = (int)startPos.y
			};
			var poly = Engine.PhysicsWorld.CreatePolygonWorldSpace(
				new Vector2[]
				{
					new Vector2(startPos.x, startPos.y),
					new Vector2(startPos.x, startPos.y + 32),
					new Vector2(startPos.x + 32, startPos.y + 32),
					new Vector2(startPos.x + 32, startPos.y)
				},1f);
			var bod = Engine.PhysicsWorld.CreateDynamicBody(startPos, 0f, new []{poly});
			bods.Add(a,bod);
			timer = 0;
		}

		foreach (var b in bods)
		{
			b.Value.AddForce(new Vector2(0,9.8f));
			b.Key.SetPosition((int)b.Value.Position.x,(int)b.Value.Position.y,b.Value.Angle,b.Key.ScaleX,b.Key.ScaleY);
		}
	};
}

void entityEmitter()
{
	double timer = 0;
	OnKeyDown += (key,_) =>  {
		if (key == Key.C)
		{
			Engine.Clear = !Engine.Clear;
		}
	};
	Update += () =>
	{
		timer += Engine.DeltaTime;
		if (timer > 0.00001)
		{
			var startPos = new Vector2(InputSystem.MouseX, InputSystem.MouseY);
			var rand = RandUnitCircle();
			new Shape(new Color(Palettes.ENDESGA[Quick.Random.Next(Palettes.ENDESGA.Count)])) {
				X = (int)startPos.x,
				Y = (int)startPos.y,
				DX = rand.x * 4,
				DY = rand.y * 4
			};
			timer = 0;
		}
	};
}

void collision()
{
	Color pt = Palettes.ENDESGA[1];
	Color pointer_col = Palettes.ENDESGA[9];
	Color no_collide = Palettes.ENDESGA[7];
	Color collide = Palettes.ENDESGA[3];
	
	var pointer = new Shape(pointer_col){Name = "pointer",Width = 1, Height = 1};
	var static_collider = new Shape(no_collide)
	{
		Name = "static_collider",
		X = 100,
		Y = 100
	};
	Shape ptB = null;
	Update += () =>
	{
		if(ptB != null){ptB.DestroyImmediate();}
		static_collider.Rotation = (float)Engine.Time;
		static_collider.ScaleX = MathF.Sin((float)Engine.Time) + 2;
		static_collider.ScaleY = MathF.Sin((float)Engine.Time) + 2;
		
		pointer.SetPosition((int)InputSystem.MouseX,(int)InputSystem.MouseY,0,1,1);
		static_collider.Color = Checks.CheckCollision(pointer, static_collider)
			? collide
			: no_collide;
		var pts = Checks.GetClosestPoints(pointer, static_collider);
		ptB = new Shape(pt)
		{
			X = (int)pts.b.X,
			Y = (int)pts.b.Y,
			Width = 5,
			Height = 5
		};
		// Console.WriteLine(Checks.GetCollisionInfo(pointer,static_collider));
	};
}

void grid()
{
	Color shape1c = Palettes.ENDESGA[9];
	Color shape2c = Palettes.ENDESGA[8];
	var shapes1 = new List<Shape>();
	var shapes2 = new List<Shape>();
	Grid g = new Grid((width/2f,height/2f), (0.5f, 0.5f), 10, 10, (0.5f,0.5f), 30, 30);
	foreach (var p in g.Points)
	{
		shapes1.Add(new Shape(shape1c) { X = (int)p.X, Y = (int)p.Y, Width = 5, Height = 5 });
		shapes2.Add(new Shape(shape2c) { X = (int)p.X, Y = (int)p.Y, Width = 5, Height = 5 });
	}
	Update += () =>
	{
		g.ScaleX = 1f;
		g.ScaleY = 1f;
		g.Rotation = (float)Engine.Time;
		g.ApplyPositionsToEntites(shapes1);
		g.Rotation = -(float)Engine.Time;
		g.ScaleX = MathF.Sin((float)Engine.Time) + 2;
		g.ScaleY = g.ScaleX;
		g.ApplyPositionsToEntites(shapes2);
	};
}

void particleSystem()
{
	var startColor = Palettes.ENDESGA[4];
	var endColor = Palettes.ENDESGA[16];
	var emitter = new ParticleEmitter(
		new(100000, 100, new ParticleEmitterComponent.ParticleConfig()))
	{
		X = 200,
		Y = 200
	};
	Update += () =>
	{
		MoveToMouse(emitter);
		// DrawEditGUIForObject("particle config",ref emitter.Config.ParticleConfig);
		DrawEditGUIForObject("emitter",ref emitter);
		// var rand = RandUnitCircle();
		// emitter.Config.particleConfig.DX.StartValue = rand.x * 4;
		// emitter.Config.particleConfig.DY.StartValue = rand.y * 4;
	};
	OnKeyDown += (key,_) =>  {
		if (key == Key.C)
		{
			Engine.Clear = !Engine.Clear;
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