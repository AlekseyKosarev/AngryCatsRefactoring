using UnityEngine;

public class Projectile_Physics: PhysicsBase
{
    //метод launch, который выпускает снаряд
    public Collider2D collider;
    public void Launch(Vector2 dir, float force)
    {
        Rigidbody.AddForce(dir * force, ForceMode2D.Impulse);
    }

    public void OffCollider()
    {
        collider.enabled = false;
    }
    public void OnCollider()
    {
        collider.enabled = true;
    }
}