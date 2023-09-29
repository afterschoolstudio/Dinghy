using Arch.Core.Extensions;
using Dinghy;
using Dinghy.Internal.Sokol;
using static Dinghy.Quick;
using static Dinghy.InputSystem;

SpriteData logo_img = new("logo.png",10,10);
var logo = Add(logo_img);
logo.Add(new Velocity());
Events.Key.Down += (key) =>
{
	ref var vel = ref logo.Get<Velocity>();
	(int dx, int dy) v = key switch
	{
		sapp_keycode.SAPP_KEYCODE_LEFT => (-1, 0),
		sapp_keycode.SAPP_KEYCODE_RIGHT => (1, 0),
		sapp_keycode.SAPP_KEYCODE_UP => (0, -1),
		sapp_keycode.SAPP_KEYCODE_DOWN => (0, 1),
		_ => (0, 0)
	};
	vel.x += v.dx;
	vel.y += v.dy;
};

// 	
// //this basically registers a lamba to be called when the update system itself sees the event in update
// On(KeyDown.Space, () =>
// {
// 	ref var position = ref e.Get<Position>();    // Get reference to the position.
// 	position.X++;                                     // Update x.
// 	position.Y++;
// });
//or just add player movement component?

Engine.Run();


/*
add(sprite with tex = res.ship)
add(new sprite(res.ship))



```c#
using Dinghy;
using static Dinghy.Engine;


Init();
var ship = new Ship(true);
var bullets = new List<Bullet>();
var asteroids = new List<Asteroids>();
for (int i = 0; i < 10; i++) {
asteroids.Add(new Asteroid(
	Screen.Width / 2 + Random(0,Screen.Width),
	Random(0,Screen.Height),
	true));
}

Events.KeyPressed += ((key) =>
{
	ship.Shift(key switch {
		Key.LeftArrow => (-1,0),
		Key.RightArrow => (1,0),
		Key.UpArrow => (0,1),
		Key.DownArrow => (0,-1)
	_ => (0,0)
});


if(key == Key.Space){

bullets.Add(new Bullet(ship.X,ship.Y,true);

}

}

  

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