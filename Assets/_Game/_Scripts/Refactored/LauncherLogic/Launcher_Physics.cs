using UnityEngine;

public class Launcher_Physics: MonoBehaviour
{
    [SerializeField] private Collider2D launcherCollider;
    private void Start()
    {
        launcherCollider.isTrigger = true;
    }

    public void PausePhysics()
    {
        launcherCollider.enabled = false;
    }

    public void ResumePhysics()
    {
        launcherCollider.enabled = true;
    }
}