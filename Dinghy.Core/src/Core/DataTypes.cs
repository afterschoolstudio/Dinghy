using Dinghy.Internal.STB;

namespace Dinghy;

public record TextureData(string texturePath);
public record SpriteData
{
    public TextureData TextureData { get; init; }
    public Rect Rect { get; set; }
    public SpriteData(TextureData Texture)
    {
        TextureData = Texture;
        //get the default frame from STB (full frame)
        var fileBytes = File.ReadAllBytes(TextureData.texturePath);
        unsafe
        {
            fixed (byte* imgptr = fileBytes)
            {
                int imgx, imgy, channels;
                var ok = STB.stbi_info_from_memory(imgptr, fileBytes.Length, &imgx, &imgy, &channels);
                Rect = new Rect(0, 0, imgx, imgy);
            }
        }
    }
    public SpriteData(TextureData Texture, Rect Rect)
    {
        TextureData = Texture;
        this.Rect = Rect;
    }
}

public record AnimatedSpriteData(TextureData TextureData, HashSet<Resources.Animation> Animations);