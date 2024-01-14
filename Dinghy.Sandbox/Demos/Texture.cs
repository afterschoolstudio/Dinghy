namespace Dinghy.Sandbox.Demos;

[DemoScene("01 Texture")]
public class Texture : Scene
{
    private Resources.Texture conscriptImage;
    private SpriteData fullConscript;
    public record ImageAsset
    {
        public Resources.Texture Texture { get; init; }
        public SpriteData SpriteData { get; init; }
        public ImageAsset(string Path)
        {
            this.Path = Path;
            Texture = new (Path);
            SpriteData = new(Texture);
        }

        public string Path { get; init; }

        public void Deconstruct(out string Path)
        {
            Path = this.Path;
        }
    }
    public override void Preload()
    {
        // conscriptImage = new TextureData("res/conscript.png");
        conscriptImage = new Resources.Texture(Res.Assets.conscript.AsTextureData);
        fullConscript = new(conscriptImage);
        var asd = new Resources.Texture(Res.Assets.logo2.Path);
    }

    public override void Create()
    {
        Engine.SetTargetScene(this);
        new Sprite(fullConscript){X = Engine.Width/2f,Y = Engine.Height/2f,PivotX = 256,PivotY=256};
    }
}