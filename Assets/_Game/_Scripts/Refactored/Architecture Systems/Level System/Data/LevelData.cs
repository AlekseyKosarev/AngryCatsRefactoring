using System;
using System.Collections.Generic;
using DS.Models;

[Serializable]
public class LevelData: DataEntity
{
    public string levelName;
    public int levelId;
    public int authorId;
    
    public int grade;
    
    public List<MaterialData> materials;
    //public List<> CatData ProjectileData
}