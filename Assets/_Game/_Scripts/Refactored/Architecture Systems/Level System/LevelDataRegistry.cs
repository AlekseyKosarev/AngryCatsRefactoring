using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class LevelDataRegistry
{
    private List<GameObject> _itemsOnLevel = new();
    private Dictionary<int, GameObject> allItemsInGame = new();
    public LevelSaver levelSaver;
    
    public void Init()
    {
        GetAllDataFromResources();
        levelSaver = new LevelSaver();
        InitLevelSaver();
    }

    private async void InitLevelSaver()
    {
        var data = await levelSaver.LoadLevels();
        if (data != null)
        {
            Debug.Log("WOOOOOwW");
        }
    }
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
        GameObject[] itemsPrefabs = Resources.LoadAll<GameObject>($"Materials");
        Debug.Log("...........................");
        foreach (var prefab in itemsPrefabs)
        {
            var materialBase = prefab.GetComponent<Material_Base>();
            var itemData = materialBase.itemData;
            allItemsInGame.Add(itemData.Id, prefab);
            // Debug.Log("Loaded ScriptableObject: " + materialBase.name);
        }
    }
    public GameObject GetPrefab(int id)
    {
        if(!allItemsInGame.ContainsKey(id)) return null;
        return allItemsInGame[id];
    }
    
}