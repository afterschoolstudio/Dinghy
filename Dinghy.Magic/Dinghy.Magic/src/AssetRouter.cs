using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.CodeAnalysis;

namespace Dinghy.Magic;

public static class AssetRouter
{
    public static void HandleResFiles(GeneratorExecutionContext ctx, IEnumerable<(AdditionalText file,string ext)> resFiles)
    { 
        var cw = new Utils.CodeWriter();
        cw.AddLine(@"
using static Dinghy.Core.Assets;

namespace Res;

");
        cw.OpenScope("public static partial class Assets");
//         // cw.AddLine("/*");
//         cw.AddLine("using Dinghy;");
//         cw.AddLine("namespace Res;");
//             cw.OpenScope("public static partial class Assets");
//                 cw.AddLine("public record Asset(string Path);");
//                 cw.AddLine(@$"
//     public record TextureAsset(string Path) : Asset(Path) 
//     {{
//         public Resources.Texture Texture = new (Path,loadImmediate:false);
//         public void Load(bool forceReload = false) => Texture.Load(forceReload);
//         //public Rect R = ... - maybe someway of predeclaring Rects with meta?
//         public Sprite CreateSprite(Rect? r = null, Scene? scene = null, bool startEnabled = true)
//         {{
//             Texture.Load();
//             return new Sprite(new SpriteData(Texture,r != null ? (Rect)r : Texture.GetFullRect()),scene,startEnabled);
//         }}
//     }}
// ");
        
        foreach (var f in resFiles)
        {
            RouteAsset(ctx,cw,f.file,f.ext);
        }
        
        cw.CloseScope();
        
        ctx.AddSource($"Res.g.cs", cw.ToString());
    }
    public static void RouteAsset(GeneratorExecutionContext context, Utils.CodeWriter cw, AdditionalText t, string ext)
    {
        switch (ext)
        {
            case "png":
            case "jpeg":
                cw.AddLine($"public static TextureAsset {Path.GetFileNameWithoutExtension(t.Path)} = new(@\"{t.Path}\");");
                break;
            case "aseprite":
            case "tmx":
            case "ldtx":
            case "cue":
            default:
                break;
        }
    }
}