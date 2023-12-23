namespace Dinghy.Sandbox.Demos;
using static Dinghy.Quick;

[DemoScene("06 Bunnymark")]
public class BunnyMark : Scene
{
    private TextureData logoImage;
    private SpriteData logo;
    public override void Preload()
    {
        var logoImage = new TextureData("logo.png");
        logo = new SpriteData(logoImage);
    }

    TestBunny b;
    int bunnies = 10000;
    public override void Create()
    {
        Engine.SetTargetScene(this);
        for (int i = 0; i < bunnies; i++)
        {
            b = new TestBunny(logo);
            b.SetVelocity(RandFloat() * 10,RandFloat()*10-5);
        }
        Engine.DebugTextStr = $"{bunnies} buns";
        OnKeyDown += KeyDownListener;
    }

    void KeyDownListener(Key key, List<Modifiers> mods)
    {
        int addedbuns = 1000;
        if (key == Key.SPACE)
        {
            for (int i = 0; i < addedbuns; i++)
            {
                b = new TestBunny(logo);
                b.SetVelocity(RandFloat() * 10,RandFloat()*10-5);
            }
            bunnies += addedbuns;
            Engine.DebugTextStr = $"{bunnies} buns";
        }
    }

    public override void Cleanup()
    {
        OnKeyDown -= KeyDownListener;
    }
}