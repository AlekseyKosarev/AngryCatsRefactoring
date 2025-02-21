using System.Collections.Generic;
using _Game._Scripts.Copy.Projectile;

namespace _Game._Scripts.Copy.Structs
{
    public struct MapData
    {
        public string Name;
        public Dictionary<ProjectilesTypes, int> Projectiles;
        public List<TileData> Tiles;

        public MapData(string name, List<ProjectilesTypes> types, List<TileData> tiles)
        {
            Name = name;
            Projectiles = new Dictionary<ProjectilesTypes, int>();
            foreach (var type in types)
            {
                if(Projectiles.ContainsKey(type))
                    Projectiles[type] += 1;
                else
                    Projectiles.Add(type, 1);
            }
            Tiles = tiles;
        }
    }
}
