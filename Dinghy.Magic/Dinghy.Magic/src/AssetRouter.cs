using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.CodeAnalysis;

namespace Dinghy.Magic;

public static class AssetRouter
{
    public static void HandleResFiles(GeneratorExecutionContext ctx, IEnumerable<(AdditionalText file,string ext)> resFiles)
    {
        var cw = new CodeWriter();
        cw.OpenScope("namespace Res");
            cw.OpenScope("public static partial class Assets");
                cw.AddLine("public record Asset(string Path);");
                cw.AddLine(@$"
public record ImageAsset(string Path) : base(Path) 
{{
    public TextureData TextureData = new (Path);
    public SpriteData SpriteData = new(TextureData);
}}
");
                cw.CloseScope();
        
        foreach (var f in resFiles)
        {
            RouteAsset(ctx,cw,f.file,f.ext);
        }
        
        cw.CloseScope();
        cw.CloseScope();
        
        ctx.AddSource($"Res.g.cs", cw.ToString());
    }
    public static void RouteAsset(GeneratorExecutionContext context, CodeWriter cw, AdditionalText t, string ext)
    {
        //var text = additionalFile.GetText();
        
        cw.AddLine($"public static Asset {Path.GetFileNameWithoutExtension(t.Path)} = new(\"{t.Path}\");");
        
        //need to handle actual content
        switch (ext)
        {
            case "aseprite":
            case "tmx":
            case "ldtx":
            case "cue":
            default:
                break;
        }
    }
}