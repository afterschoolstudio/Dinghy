using Bullseye.Internal;
using System.Collections.Generic;
using System.Text;
using static Bullseye.Targets;
using static SimpleExec.Command;

//NOTE: Requires ClangSharpPInvokeGenerator to be installed as a global tool

var bindgenBase = new rsp("base", 
[
    new ("config",
    [
        "latest-codegen",
        "single-file",
        "exclude-funcs-with-body",
        "generate-aggressive-inlining",
        "generate-file-scoped-namespaces",
        "log-exclusions",
        "log-potential-typedef-remappings",
        "log-visited-files",
        "generate-cpp-attributes"
    ]),
    new ("additional",[
        "-Wno-ignored-attributes",
        "-Wno-unsupported-attribute"
    ])
]);

var sokol_settings = new rsp("sokol_settings", rspInclude: bindgenBase, flags:
[
    new("include-directory", [
        "/Applications/Xcode.app/Contents/Developer/Platforms/MacOSX.platform/Developer/SDKs/MacOSX.sdk/usr/include",
        "/Library/Developer/CommandLineTools/usr/lib/clang/13.0.0/include/",
        "./libs/sokol/src/sokol"
    ]),
    new("define-macro", [
        "SOKOL_DLL",
        "SOKOL_NO_ENTRY",
        "SOKOL_TRACE_HOOKS"
    ]),
    new("namespace", "Dinghy.Internal.Sokol"),
    new("libraryPath", "sokol")
]);

var sokol = new lib("sokol", [
    new ("sokol_app", 
        "./libs/sokol/src/sokol/sokol_app.h",
        "sapp_",
        "App",
        "../Dinghy.Core/src/generated/lib/sokol/Sokol.App.cs",
        rspInclude:sokol_settings),
    new ("sokol_audio", 
        "./libs/sokol/src/sokol/sokol_audio.h",
        "saudio_",
        "Audio",
        "../Dinghy.Core/src/generated/lib/sokol/Sokol.Audio.cs",
        rspInclude:sokol_settings),
    new ("sokol_color", 
        "./libs/sokol/bindgen/sokol_color_bindgen_helper.h",
        "sg_color_",
        "Color",
        "../Dinghy.Core/src/generated/lib/sokol/Sokol.Color.cs",
        [
            new("traverse","./libs/sokol/src/sokol/util/sokol_color.h"),
        ],
        rspInclude:sokol_settings),
    new ("sokol_debugtext", 
        "./libs/sokol/bindgen/sokol_debugtext_bindgen_helper.h",
        "sdtx_",
        "DebugText",
        "../Dinghy.Core/src/generated/lib/sokol/Sokol.DebugText.cs",
        [
            new("traverse","./libs/sokol/src/sokol/util/sokol_debugtext.h"),
        ],
        rspInclude:sokol_settings),
    new ("sokol_gfx", 
        "./libs/sokol/src/sokol/sokol_gfx.h",
        "sg_",
        "Gfx",
        "../Dinghy.Core/src/generated/lib/sokol/Sokol.Graphics.cs",
        rspInclude:sokol_settings),
    new ("sokol_gfx_imgui", 
        "./libs/sokol/bindgen/sokol_gfx_imgui_bindgen_helper.h",
        "sg_imgui_",
        "GfxDebugGUI",
        "../Dinghy.Core/src/generated/lib/sokol/Sokol.Graphics.DebugGUI.cs",
        [
            new("traverse","./libs/sokol/src/sokol/util/sokol_gfx_imgui.h"),
            new("remap","FILE*=@void*"),
        ],
        rspInclude:sokol_settings),
    new ("sokol_glue", 
        "./libs/sokol/bindgen/sokol_glue_bindgen_helper.h",
        "sg_",
        "Glue",
        "../Dinghy.Core/src/generated/lib/sokol/Sokol.Graphics.Glue.cs",
        [
            new("traverse","./libs/sokol/src/sokol/sokol_glue.h")
        ],
        rspInclude:sokol_settings),
    new ("sokol_gp", 
        "./libs/sokol/bindgen/sokol_gp_bindgen_helper.h",
        "sgp_",
        "GP",
        "../Dinghy.Core/src/generated/lib/sokol/Sokol.GP.cs",
        [
            new("traverse","./libs/sokol/src/sokol_gp/sokol_gp.h")
        ],
        rspInclude:sokol_settings),
    new ("sokol_imgui", 
        "./libs/sokol/bindgen/sokol_imgui_bindgen_helper.h",
        "simgui_",
        "ImGUI",
        "../Dinghy.Core/src/generated/lib/sokol/Sokol.ImGUI.cs",
        [
            new("traverse",[
                "./libs/sokol/src/sokol/util/sokol_imgui.h",
                "./libs/cimgui/src/cimgui/cimgui.h"
            ]),
            new("remap",[
                "FILE*=@void*",
                "__sFILE*=@void*",
                "__arglist=@params string[] args"
            ]),
        ],
        rspInclude:sokol_settings),
    new ("sokol_log", 
        "./libs/sokol/src/sokol/sokol_log.h",
        "",
        "Log",
        "../Dinghy.Core/src/generated/lib/sokol/Sokol.Log.cs",
        rspInclude:sokol_settings),
    new ("sokol_time", 
        "./libs/sokol/src/sokol/sokol_time.h",
        "stm_",
        "Time",
        "../Dinghy.Core/src/generated/lib/sokol/Sokol.Time.cs",
        rspInclude:sokol_settings),
]);

var stb_settings = new rsp("stb_settings", rspInclude: bindgenBase, flags:
[
    new("include-directory",
    [
        "/Applications/Xcode.app/Contents/Developer/Platforms/MacOSX.platform/Developer/SDKs/MacOSX.sdk/usr/include",
        "/Library/Developer/CommandLineTools/usr/lib/clang/13.0.0/include/",
        "./libs/stb/src/stb"
    ]),
    new("namespace", "Dinghy.Internal.STB"),
    new("libraryPath", "stb")
]);
var stb = new lib("stb", [
    new ("stb_image", 
        "./libs/stb/src/stb/stb_image.h",
        "",
        "STB",
        "../Dinghy.Core/src/generated/lib/stb/STB.Image.cs",
        [
            new("define-macro","STBI_NO_STDIO"),
        ],
        rspInclude:stb_settings),
]);

var cute_settings = new rsp("cute_settings", rspInclude: bindgenBase, flags:
[
    new("include-directory", [
        "/Applications/Xcode.app/Contents/Developer/Platforms/MacOSX.platform/Developer/SDKs/MacOSX.sdk/usr/include",
        "./libs/cute/src/cute_headers"
    ]),
    new("namespace", "Dinghy.Internal.Cute"),
    new("libraryPath", "cute")
]);
var cute = new lib("cute", [
    new ("c2", 
        "./libs/cute/src/cute_headers/cute_c2.h",
        "",
        "C2",
        "../Dinghy.Core/src/generated/lib/cute/Cute.C2.cs",
        [
            new("traverse","./libs/cute/src/cute_headers/cute_c2.h"),
        ],
        rspInclude:cute_settings),
]);
    

List<lib> buildLibs = [
    sokol,
    stb,
    cute
];

// foreach (var rsp in sokol.bindgen)
// {
//     Console.WriteLine(rsp.Write().contents);
// }


var projectDir = Directory.GetCurrentDirectory();
Console.WriteLine(projectDir);
string bindgenpath(string libName,string rspFileName) => Path.Combine(projectDir, $"libs/{libName}/bindgen/{rspFileName}.rsp");
string buildpath(string libName) => Path.Combine(projectDir, $"libs/{libName}/build/build.zig");
Console.WriteLine(buildpath("sokol"));

foreach (var l in buildLibs)
{
    //sokol - build the lib and bindgen everything
    //sokol:build - builds the lib
    //sokol:bindgen - binds all the libs
    //sokol:bindgen:libname - binds the specified lib
    Target($"{l.libName}:build", () => Run("zig",$"build --build-file {buildpath(l.libName)}"));

    var reqRsps = new List<string>();
    foreach (var rsp in l.bindgen)
    {
        if (rsp.name == $"{l.libName}_settings")
        {
            //dont make a target for settings
            var b = rsp.Write();
            File.WriteAllText(b.name,b.contents);
            continue;
        }
        reqRsps.Add($"{l.libName}:bindgen:{rsp.name}");
        Target($"{l.libName}:bindgen:{rsp.name}:write_rsp", () =>
        {
            var b = rsp.Write();
            File.WriteAllText(b.name,b.contents);
        });
        
        Target($"{l.libName}:bindgen:{rsp.name}", DependsOn($"{l.libName}:bindgen:{rsp.name}:write_rsp"), () =>
        {
            try
            {
                Run("ClangSharpPInvokeGenerator", $"@{rsp.name}.rsp",handleExitCode: (code) =>
                {
                    if (code == 109)
                    {
                        Console.WriteLine("ERR: broken pipe (output too large?)");
                        return true;
                    }
                    return false;
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("EXECPETION: " + e);
            }
            File.Delete($"{rsp.name}.rsp"); //delete the rsp after running
        });
    }
    
    Target($"{l.libName}:bindgen", DependsOn(reqRsps.ToArray()));
    Target($"{l.libName}", DependsOn($"{l.libName}:build", $"{l.libName}:bindgen"));
}

//
// Target("npm:install", () => Run("npm","install"));
//
// // Create build target esbuild:dist target which will minify
// // CSS under static/css and add it to wwwroot/css folder
// // This build target has a depedency on `npm:install` build target
//
// Target("esbuild:dist", DependsOn("npm:install"), () => Run("npm","run minify"));
//
// // Create build target esbuild:dist target which will allow to
// // watch for changes in dev env
// // This build target has a depedency on `npm:install` build target
// Target("esbuild:watch", DependsOn("npm:install"), () => Run("npm","run watch"));
//
// // Create a build target Clean the web project output from previous build
// Target("clean", () => Run("dotnet","clean src/WebApp/WebApp.csproj"));
//
// // Create a build target to compile the web project
// // This build target depends on `clean` build target
// Target("compile", DependsOn("clean"), () => Run("dotnet","build ./src/WebApp/WebApp.csproj -c Release"));
//
// // Create a build target to watch for changes in dev
// Target("watch", () => Run("dotnet", "watch --project ./src/WebApp/WebApp.csproj"));
//
// // Create a default target
// // This target depends on `esbuild:dist` and `compile` build targets
// Target("default", DependsOn("esbuild:dist", "compile"));
//
//
// Target("build-all", DependsOn());

// run the build target requested and exit
await RunTargetsAndExitAsync(args);

public record rsp
{
    public rsp(string name, List<flag> flags, rsp? rspInclude = null)
    {
        this.name = name;
        this.flags = flags;
        this.rspInclude = rspInclude;
    }

    public rsp(string name, string file, string prefixStrip, string methodClassName, string outputFile,
        List<flag>? flags = null, rsp? rspInclude = null)
    {
        this.name = name;
        this.rspInclude = rspInclude;
        var f = new List<flag>
        {
            new("file",file),
            new("methodClassName",methodClassName),
            new("output",
                outputFile
            )
        };
        if (prefixStrip != "")
        {
            f.Add(new("prefixStrip", prefixStrip));
        }
        if (flags != null)
        {
            f = new List<flag>(f.Union(flags));
        }

        this.flags = f;

    }

    public (string name,string contents) Write()
    {
        var sb = new StringBuilder();
        if (rspInclude != null)
        {
            var w = rspInclude.Write();
            sb.AppendLine(w.contents);
        }

        foreach (var flag in flags)
        {
            sb.AppendLine($"--{flag.flagName}");
            foreach (var p in flag.flagParams)
            {
                sb.AppendLine($"{p}");
            }
            
        }

        return ($"{name}.rsp", sb.ToString());
    }

    public string name { get; init; }
    public List<flag> flags { get; init; }
    public rsp? rspInclude { get; init; }
}
public record flag
{
    public string flagName { get; init; }
    public List<string> flagParams { get; init; }
    public flag(string flagName, List<string> flagParams)
    {
        this.flagName = flagName;
        this.flagParams = flagParams;
    }
    public flag(string flagName, string flagParam)
    {
        this.flagName = flagName;
        this.flagParams = new List<string>{flagParam};
    }
}

public record lib(string libName, List<rsp> bindgen);


// Create a build target for npm install to make esbuild available for use