namespace Dinghy.Sandbox.Demos;

public class Texture : Scene
{
    private TextureData conscriptImage;
    private SpriteData fullConscript;
    public override void Preload()
    {
        conscriptImage = new TextureData("conscript.png");
        fullConscript = new(conscriptImage);
    }

    public override void Create()
    {
        Engine.SetTargetScene(this);
        new Sprite(fullConscript);
    }
}