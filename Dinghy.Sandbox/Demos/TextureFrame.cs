namespace Dinghy.Sandbox.Demos;

[DemoScene("02 Texture Frame")]
public class TextureFrame : Scene
{
    private Resources.Texture conscriptImage;
    private SpriteData conscriptFrame0;
    public override void Preload()
    {
        conscriptImage = new Resources.Texture("res/conscript.png");
        
        conscriptFrame0 = new(conscriptImage, new Rect(0,0,64,64));
    }

    public override void Create()
    {
        Engine.SetTargetScene(this);
        new Sprite(conscriptFrame0){X = Engine.Width/2f,Y = Engine.Height/2f,PivotX = 32,PivotY = 32};
    }
}