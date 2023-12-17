namespace Dinghy.Sandbox.Demos;

public class D02_TextureFrame : Scene
{
    private TextureData conscriptImage;
    private SpriteData conscriptFrame0;
    public override void Preload()
    {
        conscriptImage = new TextureData("conscript.png");
        
        conscriptFrame0 = new(conscriptImage, new Frame(0,0,64,64));
    }

    public override void Create()
    {
        new Sprite(conscriptFrame0,scene:this);
    }
}