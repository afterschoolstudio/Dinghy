namespace Dinghy.Sandbox.Demos;

[DemoScene("01 Texture")]
public class Texture : Scene
{
    private TextureData conscriptImage;
    private SpriteData fullConscript;
    public override void Preload()
    {
        // conscriptImage = new TextureData("res/conscript.png");
        conscriptImage = new TextureData(Res.Assets.conscript.Path);
        fullConscript = new(conscriptImage);
    }

    public override void Create()
    {
        Engine.SetTargetScene(this);
        new Sprite(fullConscript){X = Engine.Width/2f,Y = Engine.Height/2f,PivotX = 256,PivotY=256};
    }
}