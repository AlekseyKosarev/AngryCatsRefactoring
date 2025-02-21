using System.Collections.Generic;
using _Game._Scripts.Copy.Projectile;
using DG.Tweening;
using UnityEngine;

namespace _Game._Scripts.Copy.Launcher
{
    public class LauncherMagazine: Singleton<LauncherMagazine>
    {
        private List<BaseProjectile> _projectiles;
        public Transform posForProjectile;
        public float timeReloadAnim;
    
        [HideInInspector] public int countRemainingProjectiles;
        [HideInInspector] public int countProjectiles;

        private Tween _inReload;


        private void Start()
        {
            // GameManager.Instance.OnStartGame += StartGame;
            ProjectilesManager.Instance.OnInstanceProj += UpdateMagazine;
        }

        private void OnDisable()
        {
            // GameManager.Instance.OnStartGame -= StartGame;
        }
        private void StartGame()
        {
            _inReload.Kill();
            _inReload = null;
        
            // UpdateMagazine();
        
        }
        private void UpdateMagazine()
        {
            Debug.Log("update");
            _projectiles = ProjectilesManager.Instance._instanceProjectiles;
        
            countProjectiles = _projectiles.Count;
            countRemainingProjectiles = countProjectiles;
            foreach (var projectile in _projectiles)
            {
                projectile.DieCallback += MoveToLauncher;
            }
            MoveToLauncher();
        }
        private void MoveToLauncher()
        {
            if(countRemainingProjectiles <= 0) return;
            var nextProjectile = _projectiles[countProjectiles - countRemainingProjectiles];
        
            Debug.Log(nextProjectile.name);
            _inReload = nextProjectile.transform.DOMove(posForProjectile.position, timeReloadAnim).OnComplete((ResetProjectile));
        }

        private void ResetProjectile()
        {
            Debug.Log("reload");
            if(Launcher.Instance.currentProjectile != null)
                Launcher.Instance.currentProjectile.DieCallback -= MoveToLauncher;
        
            var nextProjectile = _projectiles[countProjectiles - countRemainingProjectiles];
            Launcher.Instance.currentProjectile = nextProjectile;
            countRemainingProjectiles -= 1;
        
            Launcher.Instance.ReloadEnd();
        }
    }
}