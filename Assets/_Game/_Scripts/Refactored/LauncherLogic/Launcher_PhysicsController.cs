using UnityEngine;

public class Launcher_PhysicsController: MonoBehaviour
{
    [SerializeField] private Collider2D collider;
    
    //for test TODO брать эти данные из снаряда 
    public float velocityLaunch = 10f;
    public float massProjectile = 1f;
    private void Start()
    {
        // _rigidbody = GetComponent<Rigidbody2D>();
        collider.isTrigger = true;
    }

    public void PausePhysics()
    {
        collider.enabled = false;
    }

    public void ResumePhysics()
    {
        collider.enabled = true;
    }
}