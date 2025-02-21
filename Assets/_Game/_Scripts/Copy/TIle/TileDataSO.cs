using UnityEngine;

namespace _Game._Scripts.Copy.TIle
{
    [CreateAssetMenu(fileName = "Tile Data", menuName = "BuildSystem/TileData", order = 1)]
    public class TileDataSO : ScriptableObject
    {
        public ItemType type;//(name)
        // public Tile prefab;
        
        public float maxHp;
        public float mass;
        public float gravityScale;
    }
}