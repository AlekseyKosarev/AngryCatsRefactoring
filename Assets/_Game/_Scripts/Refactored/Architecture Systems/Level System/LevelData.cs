using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    private List<GameObject> _objectsOnLevel = new();
    private Dictionary<(MaterialType, ShapeType), GameObject> allItems = new();
    
    public void Init() => GetAllDataFromResources();
    public void AddObjectOnLevel(GameObject objectsOnLevel) 
    {
        _objectsOnLevel.Add(objectsOnLevel);
    }
    public void AddObjectsOnLevel(List<GameObject> objectsOnLevel) => _objectsOnLevel.AddRange(objectsOnLevel);
    public void RemoveObjectOnLevel(GameObject objectsOnLevel) => _objectsOnLevel.Remove(objectsOnLevel);
    public void ClearLevel() => _objectsOnLevel.Clear();
    
    public void GetAllDataFromResources()
    {
        ItemDataSo[] scriptableObjects = Resources.LoadAll<ItemDataSo>($"Assets/_Game/Prefabs/Materials/Resources");

        foreach (var so in scriptableObjects)
        {
            allItems.Add((so.MaterialType, so.ShapeType), so.Prefab);
            Debug.Log("Loaded ScriptableObject: " + so.name);
        }
    }
    public GameObject GetPrefab(MaterialType materialType, ShapeType shapeType) => allItems[(materialType, shapeType)];
    
}