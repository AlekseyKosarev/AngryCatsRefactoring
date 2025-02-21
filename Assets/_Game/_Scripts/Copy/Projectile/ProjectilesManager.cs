using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Game._Scripts.Copy.Projectile
{
    public class ProjectilesManager: Singleton<ProjectilesManager>
    {
        public List<BaseProjectile> allProjectiles; //for scene serialize
        
        public List<BaseProjectile> _instanceProjectiles = new List<BaseProjectile>();
        // private List<BaseProjectile> _currentProjectiles = new List<BaseProjectile>(); // for current map 
        // private Dictionary<ProjectilesTypes, BaseProjectile> _projectiles = new Dictionary<ProjectilesTypes, BaseProjectile>(); // for load from json...

        private Transform _projectilesParent;//this

        public Action OnInstanceProj;

        private void Start()
        {
            // CreateDict();
            GameManager.Instance.OnStartGame += ResetProjectiles;
            GameManager.Instance.OnStopGame += DestroyProjectiles;
        }
    
        private void ResetProjectiles()
        {
            DestroyProjectiles();
            SpawnProjectiles();
        }
        private void SpawnProjectiles() // тут 
        {
            foreach (var projectile in allProjectiles)
            {
                var spawnProj = Instantiate(projectile, transform.position, Quaternion.identity, transform);
                _instanceProjectiles.Add(spawnProj);
            }
            OnInstanceProj?.Invoke();
        }


        private void DestroyProjectiles()
        {
            _instanceProjectiles.RemoveAll(projectile => projectile == null);
            var count = _instanceProjectiles.Count;
            for (int i = 0; i < count; i++)
            {
                Destroy(_instanceProjectiles[i].gameObject);
            }
            _instanceProjectiles.Clear();
        }

        // public void CreateDict()
        // {
        //     _projectiles.Clear();
        //     foreach (var projectile in allProjectiles)
        //     {
        //         _projectiles.Add(projectile.type, projectile);     
        //     }
        // }

        // public void LoadCurrentProjectiles(List<ProjectilesTypes> types)//call this from load map...
        // {
        //     CreateDict();
        //     _currentProjectiles.Clear();
        //     foreach (var type in types)
        //     {
        //         _currentProjectiles.Add(_projectiles[type]);
        //     }
        // }
        // public void LoadAllProjectiles()//call this from load map...
        // {
        //     CreateDict();
        //     _currentProjectiles.Clear();
        //     foreach (var proj in allProjectiles)
        //     {
        //         _currentProjectiles.Add(proj);
        //     }
        // }
    }
}
