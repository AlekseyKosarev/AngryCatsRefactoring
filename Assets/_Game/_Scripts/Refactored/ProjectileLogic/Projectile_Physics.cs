using System;
using UnityEngine;

public class Projectile_Physics: PhysicsBase
{
    //метод launch, который выпускает снаряд
    public Collider2D collider;
    public event Action<IDamageable> OnTryDealDamage;
    public void Launch(Vector2 dir, float force)
    {
        Debug.Log("Launch Projectile");
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

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            OnTryDealDamage?.Invoke(damageable);
        }
    }

    public float GetVelocityMagnitute()
    {
        var force = Rigidbody.linearVelocity.SqrMagnitude();
        return force;
    }
}