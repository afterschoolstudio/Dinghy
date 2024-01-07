namespace Dinghy.Sandbox.Demos;
using static Dinghy.Quick;

[DemoScene("03 Animation")]
public class Animation : Scene
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

    public override void Create()
    {
        Engine.SetTargetScene(this);
        new AnimatedSprite(animatedConscript){X = Engine.Width/2f,Y = Engine.Height/2f};
    }
}