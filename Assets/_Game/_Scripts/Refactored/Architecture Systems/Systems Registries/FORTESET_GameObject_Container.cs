using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FORTESET_GameObject_Container: MonoBehaviour
{
    public List<GameObject> gameObjects;
    // public List<GameObject> gameObjectscopy;
    private bool isInit = false;
    private void Init()
    {   
        if(isInit) return;
        gameObjects = FindObjectsOfType<GameObject>(true).ToList();

        isInit = true;
    }

    public List<IPausable> GetIPausableObjects()
    {
        Init();
        return gameObjects
            .ConvertAll(x => x.GetComponent<IPausable>())
            .FindAll(x => x != null); // Убираем null значения
    }

    public List<IBuildable> GetIBuildableObjects() 
    {
        Init();
        return gameObjects
            .ConvertAll(x => x.GetComponent<IBuildable>())
            .FindAll(x => x != null); // Убираем null значения
    }

    public List<IPlayable> GetIPlayableObjects() 
    {
        Init();
        return gameObjects
            .ConvertAll(x => x.GetComponent<IPlayable>())
            .FindAll(x => x != null); // Убираем null значения
    }
    
    public List<IAnyClickHanbler> GetIAnyClickHanblers()
    {
        Init();
        return gameObjects
            .ConvertAll(x => x.GetComponent<IAnyClickHanbler>())
            .FindAll(x => x != null); // Убираем null значения
    }
}   