using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DS.Utils;
using UnityEngine;

public class LevelSaver
{
    public void SaveLevel(int id, string name, int grade)
    {
        LevelData levelData = new LevelData();
        levelData.levelId = 1;
        levelData.levelName = "Level1";
        levelData.grade = 1;
        MaterialData materialData = new MaterialData();
        levelData.materials = new List<MaterialData>();
        var objectsOnLevel = Root.Instance.LevelData.GetMaterialOnLevel();
        foreach (var item in objectsOnLevel)
        {
            ItemData itemData = item.itemData;
            materialData.itemData = itemData;
            materialData.position = new TestVector2(item.transform.position);
            materialData.rotation = item.transform.rotation.z;
            
            levelData.materials.Add(materialData);
        }

        Root.Instance.DataService.SaveAsync(KeyNamingRules.KeyFor<LevelData>(levelData.levelId), levelData);
    }
    public async UniTask<LevelData[]> LoadLevels(int levelId = -1)
    {
        
        var data = await Root.Instance.DataService.LoadAllAsync<LevelData>(KeyNamingRules.KeyFor<LevelData>());
        if (!data.IsSuccess)
        {
            Debug.Log(data.ErrorMessage);
            return null;
        }

        return data.Data;
    }
}