using UnityEngine;

public class Projectile_Physics: PhysicsBase
{
    //метод launch, который выпускает снаряд
    // public Collider2D collider;
    // public float savedCurrentForce;
    
    // public event Action<IDamageable> OnTryDealDamage;
    public void Launch(Vector2 dir, float force)
    {
        Rigidbody.AddForce(dir * force, ForceMode2D.Impulse);
    }

    // public void OnCollisionEnter2D(Collision2D other)
    // {
    //     // if (other.gameObject.TryGetComponent(out IDamageable damageable))
    //     // {
    //     //     savedCurrentForce = other.relativeVelocity.SqrMagnitude();
    //     //     OnTryDealDamage?.Invoke(damageable);
    //     // }
    // }
    // public float GetVelocityMagnitute()
    // {
    //     var force = savedCurrentForce * Rigidbody.mass;
    //     return force;
    // }
}