using Dinghy;
using Dinghy.Core.ImGUI;
using Dinghy.Sandbox.Demos;
using static Dinghy.Quick;

InputSystem.Events.Key.Down += (key,_) =>  {
	if (key == Key.C)
	{
		Engine.Clear = !Engine.Clear;
	}
};

List<DemoSceneInfo> demoTypes = new();  
List<DemoSceneInfo> genuaryDemoTypes = new();
Engine.Run(new Engine.RunOptions(800,600,"dinghy", 
	() =>
	{
		demoTypes = Util.GetDemoSceneTypes().ToList();
		genuaryDemoTypes = Util.GetGenuarySceneTypes().ToList();
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