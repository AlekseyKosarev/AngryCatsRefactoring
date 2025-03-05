using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public Transform parentEmptyObject;

    [HideInInspector] public LevelData levelData;

    public void SpawnObjectToLevel(MaterialType materialType, ShapeType shapeType, Vector3 position)
    {
        var prefabItem = levelData.GetPrefab(materialType, shapeType);
        SpawnObjectToLevel(prefabItem, position);
    }

    public void SpawnObjectToLevel(GameObject prefabItem, Vector3 position)
    {
        var itemObject = Instantiate(prefabItem, position, prefabItem.transform.rotation, parentEmptyObject);

        // levelData.AddObjectOnLevel(itemObject);

        Root.Instance.BuildableRegistry.Add(itemObject.GetComponent<IBuildable>());
        Root.Instance.PlayableRegistry.Add(itemObject.GetComponent<IPlayable>());
        Root.Instance.PausableRegistry.Add(itemObject.GetComponent<IPausable>());
        Root.Instance.AnyClickHandlerRegistry.Add(itemObject.GetComponent<IAnyClickHanbler>());
        
        itemObject.GetComponent<Material_Base>().SpawnFromBuilder();
    }

    public void LoadLevelOnScene()
    {
        var objectsOnLevel = parentEmptyObject.GetComponentsInChildren<Material_Base>();
        foreach (var item in objectsOnLevel)
        {
            item.Init();
        }
    }

    public bool CheckConflicts()
    {
        var materials = levelData.GetMaterialOnLevel();
        foreach (var material in materials)
        {
            if (material.CheckConflict())
                return true;
        }

        return false;
    }
    
}