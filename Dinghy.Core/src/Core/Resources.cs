using Dinghy.Internal.Sokol;
using Dinghy.Internal.STB;

namespace Dinghy;

public static class Resources
{
    public record Texture
    {
        public string Path { get; init; }
        public int? Width { get; private set; }
        public int? Height { get; private set; }
        public sg_image Data { get; private set; }
        public bool DataLoaded { get; private set; }
        /// <summary>
        /// Create a texture from a path. Populates Width/Height via a loading the file (so a bit slower that applying that directly)
        /// </summary>
        /// <param name="path"></param>
        public Texture(string path, int? width = null, int? height = null, bool loadImmediate = true)
        {
            Path = path;
            Width = width;
            Height = height;
            if (loadImmediate)
            {
                Load();
            }
        }
        public bool Load(bool forceReload = false)
        {
            if (DataLoaded && !forceReload) { return true; }
            if (Engine.LoadImage(Path, out var width, out var height, out var img))
            {
                Width = width;
                Height = height;
                Data = img;
                DataLoaded = true;
                return true;
            }
            DataLoaded = false;
            return false;
        }
    }
    
    public record Animation(string Name, Rect[] Frames, float animationTime = 1f)
    {
        public int FrameCount { get; } = Frames.Length;
        public float FrameTime { get; } = animationTime / Frames.Length;
    }
}

public readonly record struct Rect(float startX, float startY, float width, float height)
{
    public readonly Internal.Sokol.sgp_rect InternalRect { get; } = new sgp_rect()
    {
        x = startX,
        y = startY,
        w = width,
        h = height
    };
    
    public static implicit operator Rect((float startX, float startY, float width, float height) tuple)
    {
        return new Rect(tuple.startX, tuple.startY,tuple.width,tuple.height);
    }
}


