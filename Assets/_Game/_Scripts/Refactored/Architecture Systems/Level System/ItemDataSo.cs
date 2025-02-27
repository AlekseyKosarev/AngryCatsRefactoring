using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "LevelBuilder/ItemData", order = 0)]
public class ItemDataSo: ScriptableObject
{
    public MaterialType MaterialType;
    public ShapeType ShapeType;
    public GameObject Prefab;
}