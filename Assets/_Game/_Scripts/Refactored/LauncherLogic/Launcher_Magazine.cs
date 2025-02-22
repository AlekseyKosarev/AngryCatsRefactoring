using System.Collections.Generic;
using UnityEngine;

public class Launcher_Magazine: MonoBehaviour
{
    public List<Projectile_Launch> allProjectiles = new List<Projectile_Launch>();
    public float launchForce = 5f;
    
    private int currentProjectileIndex = 0;
    private Projectile_Launch currentProjectile;

    public bool canLaunch;
    public bool launcherIsReady;
    public void Launch(Vector2 dir)
    {
        if(!canLaunch) return;
        // if(!launcherIsReady) return;
        
        Reload();
        currentProjectile.Launch(dir, launchForce);
        launcherIsReady = false;
        currentProjectile = null;
    }
    private void Reload()
    {
        if (currentProjectile != null) return;
        
        launcherIsReady = false;
        currentProjectile = allProjectiles[currentProjectileIndex];
        
        currentProjectile.GoToLauncher(transform.position, () =>
        {
            Debug.Log("Projectile reached launcher!");
            launcherIsReady = true;
            // Здесь можно добавить дополнительные действия после завершения анимации
        });
        
        
        currentProjectileIndex++;
        if (currentProjectileIndex > allProjectiles.Count)
        {
            canLaunch = false;
            Debug.Log("Launcher is empty!");
        }
    }
    public void ResetMagazine()
    {
        launcherIsReady = false;
        canLaunch = true;
        currentProjectileIndex = 0;
        currentProjectile = null;
        foreach (var projectile in allProjectiles)
        {
            projectile.Restart();
        }
        Reload();
    }
    public float GetMassProjectile()
    {
        return currentProjectile.GetComponent<Rigidbody2D>().mass;
    }
}