using Arch.Core.Extensions;
using Dinghy;
using static Dinghy.Quick;

var conscriptImage = new TextureData("conscript.png");
var logoImage = new TextureData("logo.png");

// texture();
// textureFrame();
// animation();
// simpleUpdate();
// interaction();
// bunny();
asteroidsGame();

Engine.Run();

void texture()
{
	SpriteData fullConscript = new(conscriptImage);
	Add(new Sprite(fullConscript));
}

void textureFrame()
{
	SpriteData conscriptFrame0 = new(conscriptImage, new Frame(0,0,64,64));
	Add(new Sprite(conscriptFrame0));
}

void animation()
{
	AnimatedSpriteData animatedConscript = new AnimatedSpriteData(
		conscriptImage,
		new() { new("test", HorizontalFrameSequence(0, 0, 64, 64, 4),
			0.4f) });
	Add(new AnimatedSprite(animatedConscript));
}

void simpleUpdate()
{
	SpriteData conscriptFrame0 = new(conscriptImage, new Frame(0,0,64,64));
	var e = Add(new Sprite(conscriptFrame0));
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
	var e = Add(new AnimatedSprite(animatedConscript));
	
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
		Add(b);
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
				Add(b);
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
	var player = Add(new Sprite(logo){Name = "player"});
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
			var a = Add(new Sprite(conscript) {
				X = player.X, 
				Y = player.Y
			});
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
			var a = Add(new Sprite(conscript) {
				X = Engine.Width, 
				Y = (int)((Engine.Height / 2f) + MathF.Sin(RandFloat() * 2 - 1) * Engine.Height / 2.5f)
			});
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