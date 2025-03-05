using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    private List<GameObject> _itemsOnLevel = new();
    private Dictionary<(MaterialType, ShapeType), GameObject> allItemsInGame = new();
    
    public void Init() => GetAllDataFromResources();
    public void AddObjectOnLevel(GameObject objectsOnLevel) 
    {
        _itemsOnLevel.Add(objectsOnLevel);
    }
    public void AddObjectsOnLevel(List<GameObject> objectsOnLevel) => _itemsOnLevel.AddRange(objectsOnLevel);
    public void RemoveObjectOnLevel(GameObject objectsOnLevel) => _itemsOnLevel.Remove(objectsOnLevel);
    public void ClearLevel() => _itemsOnLevel.Clear();
    public List<Material_Base> GetMaterialOnLevel() => _itemsOnLevel.ConvertAll(x => x.GetComponent<Material_Base>());
    
    public void GetAllDataFromResources()
    {
        ItemDataSo[] scriptableObjects = Resources.LoadAll<ItemDataSo>($"Assets/_Game/Prefabs/Materials/Resources");

        foreach (var so in scriptableObjects)
        {
            allItemsInGame.Add((so.MaterialType, so.ShapeType), so.Prefab);
            Debug.Log("Loaded ScriptableObject: " + so.name);
        }
    }
    public GameObject GetPrefab(MaterialType materialType, ShapeType shapeType) => allItemsInGame[(materialType, shapeType)];
    
}