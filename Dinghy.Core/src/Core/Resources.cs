using Dinghy.Internal.Sokol;

namespace Dinghy;

public static class Resources
{
    static Dictionary<string, LoadedImageResource> LoadedImageResources = new Dictionary<string, LoadedImageResource>();
    public record LoadedImageResource(sg_image sg_image); 
    public record Image(string texture, bool alphaIsTransparecy)
    {
        public LoadedImageResource internalData { get; private set; }
        public bool loaded { get; private set; } = false;
        public int width { get; private set; }
        public int height { get; private set; }
        public void Load()
        {
            //we dont load the same image more than once
            if (LoadedImageResources.TryGetValue(texture, out var loadedResource))
            {
                internalData = loadedResource;
                loaded = true;
                return;
            }
            var img = Engine.LoadImage(texture, out var w, out var h);
            // var state = Internal.Sokol.Gfx.query_image_state(img);
            // Console.WriteLine(state);
            internalData = new LoadedImageResource(img);
            LoadedImageResources.Add(texture,internalData);
            width = w;
            height = h;
            // Console.WriteLine($"loaded {texture} with dim {width},{height}");
            loaded = true;
            return;
        }
    }
}


