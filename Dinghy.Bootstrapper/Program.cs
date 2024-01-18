using Bullseye.Internal;
using System.Collections.Generic;
using static Bullseye.Targets;
using static SimpleExec.Command;

//NOTE: Requires ClangSharpPInvokeGenerator to be installed as a global tool

var buildDict = new Dictionary<Lib, List<string>>(){
    {
        //the string lists are .rsp files
        Lib.sokol, new List<string>()
        {
            "sokol_app",
            "sokol_audio",
            "sokol_color",
            "sokol_debugtext",
            "sokol_gfx",
            "sokol_gfx_imgui",
            "sokol_glue",
            "sokol_gp",
            "sokol_imgui",
            "sokol_log",
            "sokol_time"
        }
    },
    {
        Lib.stb, new List<string>()
        {
            "stb_image"
        }
    },
    {
        Lib.cute, new List<string>()
        {
            "stb_image"
        }
    }
};

var projectDir = Directory.GetCurrentDirectory();
Console.WriteLine(projectDir);
string bindgenpath(string libName,string rspFileName) => Path.Combine(projectDir, $"libs/{libName}/bindgen/{rspFileName}.rsp");
string buildpath(string libName) => Path.Combine(projectDir, $"libs/{libName}/build/build.zig");
Console.WriteLine(buildpath("sokol"));


foreach (var kvp in buildDict)
{
    //sokol - build the lib and bindgen everything
    //sokol:build - builds the lib
    //sokol:bindgen - binds all the libs
    //sokol:bindgen:libname - binds the specified lib
    var libName = kvp.Key.ToString();
    Target($"{libName}:build", () => Run("zig",$"build --build-file {buildpath(libName)}"));

    var reqRsps = new List<string>();
    foreach (var rsp in kvp.Value)
    {
        reqRsps.Add($"{libName}:bindgen:{rsp}");
        Target($"{libName}:bindgen:{rsp}", () => Run("ClangSharpPInvokeGenerator",$"\"@{bindgenpath(libName,rsp)}\""));
        // Target($"{libName}:bindgen:{rsp}", () => Run("ClangSharpPInvokeGenerator",$"""@sokol_time.rsp)"""));
    }
    
    Target($"{libName}:bindgen", DependsOn(reqRsps.ToArray()));
    Target($"{libName}", DependsOn($"{libName}:build", $"{libName}:bindgen"));
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

public enum Lib
{
    sokol,
    stb,
    cute
}


// Create a build target for npm install to make esbuild available for use