namespace Dinghy.Sandbox.Demos;
using static Dinghy.Quick;

[DemoScene("05 Interaction")]
public class Interaction : Scene
{
    private TextureData conscriptImage;
    private AnimatedSpriteData animatedConscript;
    public override void Preload()
    {
        conscriptImage = new TextureData("conscript.png");
        animatedConscript = new AnimatedSpriteData(
            conscriptImage,
            new() { new("test", HorizontalFrameSequence(0, 0, 64, 64, 4),
                0.4f) });
    }

    private AnimatedSprite e;
    public override void Create()
    {
        Engine.SetTargetScene(this);
        
        e = new AnimatedSprite(animatedConscript);
        Console.WriteLine("subbing");
        InputSystem.Events.Key.Down += KeyDownListener;
    }

    void KeyDownListener(Key key, List<Modifiers> mods)
    {
        (float dx, float dy) v = key switch {
            Key.LEFT => (-1f, 0),
            Key.RIGHT => (1f, 0),
            Key.UP => (0, -1f),
            Key.DOWN => (0, 1f),
            _ => (0, 0)
        };
        e.DX += v.dx;
        e.DY += v.dy;
    }

    public override void Cleanup()
    {
	    Console.WriteLine("unsubbing");
	    InputSystem.Events.Key.Down -= KeyDownListener;
    }
}

/*
 
saving old style here as a ref - its quicker to write!


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
   
   Engine.Run() 
*/