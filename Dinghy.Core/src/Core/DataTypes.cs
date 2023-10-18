using Dinghy.Internal.STB;

namespace Dinghy;

public record TextureData(string texturePath);
public record SpriteData
{
    public TextureData TextureData { get; init; }
    public Frame Frame { get; set; }
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
                Frame = new Frame(0, 0, imgx, imgy);
            }
        }
    }
    public SpriteData(TextureData Texture, Frame Frame)
    {
        TextureData = Texture;
        this.Frame = Frame;
    }
}

public record AnimatedSpriteData(TextureData TextureData, HashSet<Resources.Animation> Animations);