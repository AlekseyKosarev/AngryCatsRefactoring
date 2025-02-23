using System.Collections.Generic;
using UnityEngine;

public class Launcher_Magazine: MonoBehaviour
{
    public List<Projectile_Launch> allProjectiles = new List<Projectile_Launch>();
    public float launchForce = 5f;
    public float reloadDuration = 0.5f;
    public Transform pointOfLaunch;
    
    private int currentProjectileIndex = 0;
    private Projectile_Launch currentProjectile;
    private Projectile_Launch nextProjectile;

    public bool launcherIsEmpty;
    public bool launcherIsReady;
    public void Launch(Vector2 dir)
    {
        if(launcherIsEmpty) return;
        if(currentProjectile == null) return;
        // if(!launcherIsReady) return;
        
        currentProjectile.Launch(dir, launchForce);
        LoadNewProjectile();
    }
    private void LoadNewProjectile()
    {
        if (currentProjectileIndex >= allProjectiles.Count) launcherIsEmpty = true;
        
        if (launcherIsEmpty)
        {
            currentProjectile = null;
            return;
        }
        
        launcherIsReady = false;
        currentProjectile = allProjectiles[currentProjectileIndex];
        currentProjectileIndex++;
        currentProjectile.GoToLauncher(pointOfLaunch.position, reloadDuration, () =>
        {
            launcherIsReady = true;
            // Здесь можно добавить дополнительные действия после завершения анимации
        });
    }

    public void ResetProjectiles()
    {
        launcherIsReady = false;
        launcherIsEmpty = false;
        currentProjectileIndex = 0;
        currentProjectile = null;
        // foreach (var projectile in allProjectiles)
        // {
        //     projectile.Restart();
        // }
    }

    public void ResetMagazine()
    {
        ResetProjectiles();
        LoadNewProjectile();
    }
    public float GetMassProjectile()
    {
        return currentProjectile.GetComponent<Rigidbody2D>().mass;
    }
    public bool CanShoot()
    {
        return !launcherIsEmpty && launcherIsReady;
    }
}