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
        var p = new Position(pos.X, pos.Y, scale.X, scale.Y, rotation, 0f, 0);
        sgp_rect source = default;
        source.x = src.Value.X;
        source.y = src.Value.Y;
        source.w = src.Value.Width;
        source.h = src.Value.Height;
        Engine.DrawTexturedRect(p,(sg_image)texture,source);
    }

    public readonly FontstashTextManager _textureManager = new();
    public ITexture2DManager TextureManager => _textureManager;
}

public class FontstashTextManager : ITexture2DManager
{
    private Dictionary<uint, List<uint>> fontPixels = new();
    public object CreateTexture(int width, int height)
    {
        // uint WHITE = 0xFFFFFFFF;
        uint WHITE = 0xFFFF0000;
        var basePixels = new List<uint>();
        for (int i = 0; i < (width*height); i++)
        {
            basePixels.Add(WHITE);
        }
        
        var font_desc = default(sg_image_desc);
        font_desc.width = width;
        font_desc.height = height;
        font_desc.usage = sg_usage.SG_USAGE_DYNAMIC;
        unsafe
        {
            var img = Gfx.make_image(&font_desc);
            fontPixels.Add(img.id,basePixels);
            return img;
        }
    }

    public Point GetTextureSize(object texture)
    {
        var q = Gfx.query_image_desc((sg_image)texture);
        return new Point(new Size(q.width, q.height));
    }

    public Dictionary<object, List<(Rectangle bounds, byte[] data)>> frameUpdateOperations = new();
    public void SetTextureData(object texture, Rectangle bounds, byte[] data)
    {
        if (!frameUpdateOperations.ContainsKey(texture))
        {
            frameUpdateOperations.Add(texture, new List<(Rectangle, byte[])>());
        }
        frameUpdateOperations[texture].Add((bounds,data));
    }

    public void ClearTextUpdates()
    {
        frameUpdateOperations.Clear();
    }

    public void ApplyTextureUpdates()
    {
        foreach (var textureUpdate in frameUpdateOperations)
        {
            var img = (sg_image)textureUpdate.Key;
            var q = Gfx.query_image_desc(img);
            int textureWidth = q.width;
            
            foreach (var update in textureUpdate.Value)
            {
                var uintData = new List<uint>(update.data.Length / 4);
                // Convert byte array to uint array
                for (int i = 0; i < uintData.Capacity; i++)
                {
                    int byteIndex = i * 4;
                    uint color = (uint)(
                        update.data[byteIndex + 0] << 24 | // Red
                        update.data[byteIndex + 1] << 16 | // Green
                        update.data[byteIndex + 2] << 8 | // Blue
                        update.data[byteIndex + 3]); // Alpha

                    uintData.Add(color); // Use Add method to append the item
                }
                
                Console.WriteLine($"data count: {uintData.Count}");
                Console.WriteLine($"bounds: {update.bounds.X},{update.bounds.Y} w:{update.bounds.Width} h:{update.bounds.Height}");
                //debug glpyh patches
                // var letter = default(sg_image_desc);
                // letter.width = update.bounds.Width;
                // letter.height = update.bounds.Height;
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
                // //------------

                
                // patch the new uint data in currentPixels
                var bounds = update.bounds;
                for (int y = 0; y < bounds.Height; y++)
                {
                    for (int x = 0; x < bounds.Width; x++)
                    {
                        //bounds.x/y are worldpos of texture
                        var textureIndex = ((bounds.Y + y) * textureWidth) + bounds.X + x;
                        int uintDataIndex = y * bounds.Width + x;
                        fontPixels[img.id][textureIndex] = uintData[uintDataIndex];
                    }
                }

                // for (int y = 0; y < bounds.Height; y++)
                // {
                //     for (int x = 0; x < bounds.Width; x++)
                //     {
                //         int currentPixelIndex = (bounds.Top + y) * textureWidth + (bounds.Left + x);
                //         int uintDataIndex = y * bounds.Width + x;
                //         if (currentPixelIndex < fontPixels[img.id].Count && uintDataIndex < uintData.Count)
                //         {
                //             fontPixels[img.id][currentPixelIndex] = uintData[uintDataIndex];
                //         }
                //     }
                // }
            }
            
            //apply batched updates
            var newPixels = new Dinghy.NativeInterop.Utils.NativeArray<uint>(fontPixels[img.id].Count);
            for (int i = 0; i < (fontPixels[img.id].Count); i++)
            {
                newPixels[i] = fontPixels[img.id][i];
            }
            unsafe
            {
                //apply the image data
                sg_image_data d = default;
                d.subimage.e0_0 = newPixels.AsSgRange();
                Gfx.update_image(img, &d);
            }
        }
        
    }
}