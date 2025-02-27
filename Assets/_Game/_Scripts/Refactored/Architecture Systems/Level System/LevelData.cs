using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    private List<GameObject> _objectsOnLevel = new();
    public void Add(GameObject objectsOnLevel) 
    {
        _objectsOnLevel.Add(objectsOnLevel);
        Print();
    }
    public void Remove(GameObject objectsOnLevel) => _objectsOnLevel.Remove(objectsOnLevel);
    public void Clear() => _objectsOnLevel.Clear();

    public void Print()
    {
        foreach (var obj in _objectsOnLevel)
        {
            Debug.Log(obj.name);
        }
    }
}