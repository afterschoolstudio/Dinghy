using System.Runtime.InteropServices;
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
Engine.Run(new Engine.RunOptions(800,600,"dinghy", 
	() =>
	{
		demoTypes = Util.GetDemoSceneTypes().ToList();
		genuaryDemoTypes = Util.GetGenuarySceneTypes().ToList();

		// var scene = new Dungeon();
		// scene.Mount(0);
		// scene.Load(() => scene.Start());
	}, 
	() =>
	{
		drawDemoOptions();
	}
	));

void drawDemoOptions()
{
	ImGUIHelper.Wrappers.BeginMainMenuBar();
	if (ImGUIHelper.Wrappers.BeginMenu("Dinghy"))
	{
		if (ImGUIHelper.Wrappers.BeginMenu("Demos"))
		{
			Scene? scene = null;

			if (ImGUIHelper.Wrappers.BeginMenu("Examples"))
			{
				foreach (var type in demoTypes)
				{
					if (ImGUIHelper.Wrappers.MenuItem(type.Name))
					{
						scene = Util.CreateInstance(type.Type) as Scene;
						scene.Name = type.Name;
					}
				}
				ImGUIHelper.Wrappers.EndMenu();
			}
			
			if (ImGUIHelper.Wrappers.BeginMenu("Genuary"))
			{
				foreach (var type in genuaryDemoTypes)
				{
					if (ImGUIHelper.Wrappers.MenuItem(type.Name))
					{
						scene = Util.CreateInstance(type.Type) as Scene;
						scene.Name = type.Name;
					}
				}
				ImGUIHelper.Wrappers.EndMenu();
			}

			if (scene != null)
			{
				Engine.TargetScene.Unmount(() =>
				{
					scene.Mount(0);
					scene.Load(() => scene.Start());
				});
			}
			ImGUIHelper.Wrappers.EndMenu();
		}
		ImGUIHelper.Wrappers.EndMenu();
	}
	ImGUIHelper.Wrappers.EndMainMenuBar();
}