﻿using System.Runtime.InteropServices;
using Dinghy;
using Dinghy.Core.ImGUI;
using Dinghy.Sandbox;
using Dinghy.Sandbox.Demos;
using Dinghy.Sandbox.Demos.dungeon;
using static Dinghy.Quick;
using Collision = Dinghy.Sandbox.Demos.Collision;

NativeLibResolver.kick();

InputSystem.Events.Key.Down += (key,_) =>  {
	if (key == Key.C)
	{
		Engine.Clear = !Engine.Clear;
	}
};

List<DemoSceneInfo> demoTypes = new();  
List<DemoSceneInfo> genuaryDemoTypes = new();
// Console.WriteLine(AppContext.GetData("NATIVE_DLL_SEARCH_DIRECTORIES"));
Engine.Run(new Engine.RunOptions(1920,1080,"dinghy", 
	() =>
	{
		demoTypes = Util.GetDemoSceneTypes().ToList();
		genuaryDemoTypes = Util.GetGenuarySceneTypes().ToList();

		var scene = new Dungeon();
		scene.Mount(0);
		scene.Load(() => scene.Start());
	}, 
	() =>
	{
		drawDemoOptions();
	}
	));

void drawDemoOptions()
{
	ImGUIHelper.Wrappers.MainMenu(() =>
	{
		ImGUIHelper.Wrappers.Menu("Dinghy", () =>
		{
			ImGUIHelper.Wrappers.Menu("Demos", () =>
			{
				Scene? scene = null;
				ImGUIHelper.Wrappers.Menu("Examples", () =>
				{
					foreach (var type in demoTypes)
					{
						if (ImGUIHelper.Wrappers.MenuItem(type.Name))
						{
							scene = Util.CreateInstance(type.Type) as Scene;
							scene.Name = type.Name;
						}
					}
				});

				ImGUIHelper.Wrappers.Menu("Genuary", () =>
				{
					foreach (var type in genuaryDemoTypes)
					{
						if (ImGUIHelper.Wrappers.MenuItem(type.Name))
						{
							scene = Util.CreateInstance(type.Type) as Scene;
							scene.Name = type.Name;
						}
					}
				});

				if (scene != null)
				{
					Engine.TargetScene.Unmount(() =>
					{
						scene.Mount(0);
						scene.Load(() => scene.Start());
					});
				}
			});
		});
	});
}