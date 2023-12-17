namespace Dinghy.Sandbox.Demos;

public class D01_Texture : Scene
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
        new Sprite(fullConscript,scene:this);
    }
}