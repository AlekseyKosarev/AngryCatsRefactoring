using System.Collections.Generic;
using UnityEngine;

public class FORTESET_GameObject_Container: MonoBehaviour
{
    public List<GameObject> gameObjects;
    
    public List<IPausable> GetIPausableObjects() 
    {
        return gameObjects
            .ConvertAll(x => x.GetComponent<IPausable>())
            .FindAll(x => x != null); // Убираем null значения
    }

    public List<IBuildable> GetIBuildableObjects() 
    {
        return gameObjects
            .ConvertAll(x => x.GetComponent<IBuildable>())
            .FindAll(x => x != null); // Убираем null значения
    }

    public List<IPlayable> GetIPlayableObjects() 
    {
        return gameObjects
            .ConvertAll(x => x.GetComponent<IPlayable>())
            .FindAll(x => x != null); // Убираем null значения
    }
}   