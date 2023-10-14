using Dinghy.Internal.Sokol;

namespace Dinghy;

public static class Resources
{
    static Dictionary<string, LoadedImageResource> LoadedImageResources = new Dictionary<string, LoadedImageResource>();
    public record LoadedImageResource(sg_image sg_image, int width, int height); 
    public record Image(string texturePath, bool alphaIsTransparecy)
    {
        public LoadedImageResource internalData { get; private set; }
        public Frame DefaultFrame { get; private set; }
        public bool loaded { get; private set; } = false;
        public int Width => internalData.width;
        public int Height => internalData.height;
        public void Load()
        {
            //we dont load the same image more than once
            if (LoadedImageResources.TryGetValue(texturePath, out var loadedResource))
            {
                internalData = loadedResource;
                loaded = true;
                return;
            }
            var img = Engine.LoadImage(texturePath, out var w, out var h);
            DefaultFrame = new Frame(0, 0, w, h); //default is the full texture
            // var state = Internal.Sokol.Gfx.query_image_state(img);
            // Console.WriteLine(state);
            internalData = new LoadedImageResource(img,w,h);
            LoadedImageResources.Add(texturePath,internalData);
            loaded = true;
        }
    }
    public record Animation(string Name, List<Frame> Frames, float animationTime = 1f)
    {
        public int FrameCount { get; } = Frames.Count;
        public float FrameTime { get; } = animationTime / Frames.Count;
    }
}

public readonly record struct Frame(int startX, int startY, int width, int height)
{
    public readonly Internal.Sokol.sgp_rect InternalRect { get; } = new sgp_rect()
    {
        x = startX,
        y = startY,
        w = width,
        h = height
    };
    
    public readonly Internal.Sokol.sgp_rect SizeRect { get; } = new sgp_rect()
    {
        x = 0,
        y = 0,
        w = width,
        h = height
    };
}


