﻿using Arch.Core;
using Arch.Core.Extensions;
using Dinghy.Core;

namespace Dinghy;

public class Scene : Entity
{
    private int sceneRenderCounter = 0;
    public int GetNextSceneRenderCounter()
    {
        var curr = sceneRenderCounter;
        sceneRenderCounter++;
        return curr;
    }
    
    public enum SceneLoadStatus
    {
        Unloaded,
        Loading,
        Loaded
    }

    public enum SceneMountStatus
    {
        Unmounted,
        Mounted
    }
    public enum SceneStatus
    {
        Inactive,
        Creating,
        Running
    }

    public SceneStatus Status = SceneStatus.Inactive; 
    public SceneMountStatus MountStatus = SceneMountStatus.Unmounted; 
    public SceneLoadStatus LoadStatus = SceneLoadStatus.Unloaded; 
    public Scene(bool startEnabled = true) : base(startEnabled,null,false)
    {
        ECSEntity.Add(new SceneComponent(Update,this));
    }

    public virtual void Update(double dt){}
/*
 * mount -> load -> start -> unmount
 */
    public void Mount(int depth)
    {
        Engine.MountedScenes.Add(depth,this);
        Engine.SceneEntityMap.Add(this,new List<Entity>());
        MountStatus = SceneMountStatus.Mounted;
    }

    public void Unmount(Action callback = null)
    {
        if (MountStatus == SceneMountStatus.Mounted)
        {
            Cleanup();
            var rmentites = new List<Entity>(Engine.SceneEntityMap[this]);
            foreach (var e in rmentites)
            {
                e.Destroy();
            }
            Events.SceneUnmounted?.Invoke(this,callback);
        }
    }
    public void Load(Action loadedCallback)
    {
        if (LoadStatus != SceneLoadStatus.Loaded)
        {
            LoadStatus = SceneLoadStatus.Loading;
            Preload();
            LoadStatus = SceneLoadStatus.Loaded;
        }
        loadedCallback?.Invoke();
    }
    
    public virtual void Preload(){}
    public void Start(bool setAsTargetScene = true)
    {
        if (MountStatus != SceneMountStatus.Mounted)
        {
            Console.WriteLine("mount and load scene before starting it");
            return;
        }
        if (LoadStatus != SceneLoadStatus.Loaded)
        {
            if (LoadStatus == SceneLoadStatus.Loading)
            {
                Console.WriteLine("scene still loading");
            }
            else
            {
                Console.WriteLine("load scene before starting it");
            }
            return;
        }
        Status = SceneStatus.Creating;
        if (setAsTargetScene)
        {
            Engine.SetTargetScene(this);
        }
        Create();
        Status = SceneStatus.Running;
    }
    public virtual void Create(){}
    public virtual void Cleanup(){}
}