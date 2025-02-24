using UnityEngine;

public class Material_Physics: PhysicsBase
{
    private IDamageable _damageableHandler;

    public override void Init()
    {
        base.Init();
        _damageableHandler = GetComponent<IDamageable>();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        var damage = other.relativeVelocity.SqrMagnitude();
        
        _damageableHandler.TryTakeDamage((int)damage);
        // Debug.Log(gameObject.name + " has " + damage);
    }
}