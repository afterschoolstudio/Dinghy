using System.Drawing;
using System.Numerics;
using Dinghy.Internal.Sokol;
using Dinghy.Internal.STB;
using FontStashSharp;
using FontStashSharp.Interfaces;
namespace Dinghy.Core;

public class FontstashRenderer : IFontStashRenderer
{
    public void Draw(object texture, Vector2 pos, Rectangle? src, FSColor color, float rotation, Vector2 scale, float depth)
    {
        (texture as FontTexture).Draw(pos, src, color, rotation, scale, depth);
    }

    public readonly FontstashTextManager _textureManager = new();
    public ITexture2DManager TextureManager => _textureManager;
}

public class FontTexture
{
    public uint WHITE = 0xFFFF0000;
    private List<uint> pixels = new();
    public Point Size;
    private bool pixelsDirty = false;
    public void Write(Rectangle bounds, byte[] data)
    {
        var uintData = new List<uint>(bounds.Width * bounds.Height);
        for (int i = 0; i < uintData.Capacity; i++)
        {
            /*
             *               uint 0
             *  byte0    byte1    byte2    byte3
             *  AAAAAAAA RRRRRRRR GGGGGGGG BBBBBBBB 
             *  00000000 00000000 00000000 00000000
             */
            
            int byteIndex = i * 4;
            uint color = (uint)(
                data[byteIndex + 0] << 24 | // Red
                data[byteIndex + 1] << 16 | // Green
                data[byteIndex + 2] << 8 | // Blue
                data[byteIndex + 3]); // Alpha
            uintData.Add(color);
        }
        
        // Console.WriteLine($"data count: {uintData.Count}");
        // Console.WriteLine($"bounds: {update.bounds.X},{update.bounds.Y} w:{update.bounds.Width} h:{update.bounds.Height}");
        
        //debug glpyh patches-------------
        // var letter = default(sg_image_desc);
        // letter.width = bounds.Width;
        // letter.height = bounds.Height;
        // var dbp = new Dinghy.NativeInterop.Utils.NativeArray<uint>(uintData.Count);
        // for (int i = 0; i < uintData.Count; i++)
        // {
        //     dbp[i] = uintData[i];
        // }
        // letter.data.subimage.e0_0 = dbp.AsSgRange();
        // unsafe
        // {
        //     Gfx.make_image(&letter);
        // }
        //------------

        
        // patch the new uint data in currentPixels
        for (int y = 0; y < bounds.Height; y++)
        {
            for (int x = 0; x < bounds.Width; x++)
            {
                //bounds.x/y are worldpos of texture
                var textureIndex = ((bounds.Y + y) * Width) + bounds.X + x;
                int uintDataIndex = y * bounds.Width + x;
                pixels[textureIndex] = uintData[uintDataIndex];
            }
        }

        pixelsDirty = true;
    }

    private bool imageBuilt;
    private sg_image internalImage;
    public int Width { get; protected set; }
    public int Height { get; protected set; }
    public FontTexture(int width, int height)
    {
        Width = width;
        Height = height;
        Size = new Point(width, height);
        for (int i = 0; i < (width*height); i++)
        {
            pixels.Add(WHITE);
        }
    }

    public void Draw(Vector2 pos, Rectangle? src, FSColor color, float rotation, Vector2 scale, float depth)
    {
        var p = new Position(pos.X, pos.Y, scale.X, scale.Y, rotation, 0f, 0);
        sgp_rect source = default;
        source.x = src.Value.X;
        source.y = src.Value.Y;
        source.w = src.Value.Width;
        source.h = src.Value.Height;

        if (pixelsDirty)
        {
            if (imageBuilt)
            {
                //sokol doesn't like you updating a texture more than once per frame
                //but fontstash writes constantly to a new texture in a given frame as it builds the font atlas
                //so we just incrementally build the atlas and trash the image resources that exist if they are dirty
                Gfx.destroy_image(internalImage);
            }
            var nativePixels = new Dinghy.NativeInterop.Utils.NativeArray<uint>(pixels.Count);
            for (int i = 0; i < pixels.Count; i++)
            {
                nativePixels[i] = pixels[i];
            }
            unsafe
            {
                //apply the image data
                sg_image_desc d = default;
                d.width = Width;
                d.height = Height;
                d.data.subimage.e0_0 = nativePixels.AsSgRange();
                internalImage = Gfx.make_image(&d);
            }
            imageBuilt = true;
            pixelsDirty = false;
        }
        Engine.DrawTexturedRect(p,internalImage,source);
    }
}

public class FontstashTextManager : ITexture2DManager
{
    public object CreateTexture(int width, int height) => new FontTexture(width, height);
    public Point GetTextureSize(object texture) => (texture as FontTexture).Size;
    public void SetTextureData(object texture, Rectangle bounds, byte[] data) => (texture as FontTexture).Write(bounds, data);
}