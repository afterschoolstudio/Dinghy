namespace Dinghy.Sandbox.Demos;

[DemoScene("15 Asteroids")]
public class AsteroidsGame : Scene
{
    private TextureData conscriptImage;
    private SpriteData fullConscript;

    private Sprite player;
    public override void Preload()
    {
        conscriptImage = new TextureData("conscript.png");
        fullConscript = new(conscriptImage,(0,0,64,64));
    }

    public override void Create()
    {
        Engine.SetTargetScene(this);
        player = new Sprite(fullConscript){Name = "player",X = Engine.Width/2f,Y = Engine.Height/2f};
        InputSystem.Events.Key.Down += OnKeyDown;
    }

    double bulletCooldown = 0;
    private void OnKeyDown(Key key, List<Modifiers> arg2)
    {
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
		    var a = new Sprite(fullConscript) {
			    X = player.X, 
			    Y = player.Y
		    };
		    a.SetVelocity(2.5f,0);
		    bulletCooldown = 0f;
	    }
    }

    private double timer = 0;
    public override void Update(double dt)
    {
	    //spawn asteroids
	    timer += Engine.DeltaTime;
	    bulletCooldown += Engine.DeltaTime;
	    if (timer > 2)
	    {
	    	var a = new Sprite(fullConscript) {
	    		X = Engine.Width, 
	    		Y = (int)((Engine.Height / 2f) + MathF.Sin(Quick.RandFloat() * 2 - 1) * Engine.Height / 2.5f)
	    	};
	    	a.SetVelocity(-2,0);
	    	timer = 0;
	    }
    }

    public override void Cleanup()
    {
	    InputSystem.Events.Key.Down -= OnKeyDown;
    }
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