namespace Dinghy.Sandbox.Demos;

[DemoScene("02 Texture Frame")]
public class TextureFrame : Scene
{
    private TextureData conscriptImage;
    private SpriteData conscriptFrame0;
    public override void Preload()
    {
        conscriptImage = new TextureData("conscript.png");
        
        conscriptFrame0 = new(conscriptImage, new Rect(0,0,64,64));
    }

    public override void Create()
    {
        Engine.SetTargetScene(this);
        new Sprite(conscriptFrame0);
    }
}