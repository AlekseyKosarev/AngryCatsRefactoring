using System.Collections.Generic;
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

    // public bool CheckContacts()
    // {
    //     var cont = new List<Collider2D>{};
    //     var countContacts = Collider.GetContacts(cont);
    //     if (countContacts > 0)
    //     {
    //         return true;
    //     }
    //     return false;
    // }
    // public void ColliderMiniScale()
    // {
    //     var offset = 0.15f;
    //     if(Collider is BoxCollider2D box)
    //     {
    //         var size = box.size;
    //         var kX = offset / transform.localScale.x;
    //         var kY = offset / transform.localScale.y;
    //         size = new Vector2(size.x - kX, size.y - kY); // нужно делать коллайдер чуть меньше, чтобы не было коллизий в редакторе
    //         box.size = size;
    //     }
    //     if(Collider is CircleCollider2D circle)
    //     {
    //         var radius = circle.radius;
    //         var kX = offset / transform.localScale.x;
    //
    //         radius -= kX;
    //         circle.radius = radius;
    //     }
    // }
    // public void ColliderNormalScale()
    // {
    //     if(Collider is BoxCollider2D box)
    //     {
    //         box.size *= 1.2f;
    //     }
    //     if(Collider is CircleCollider2D circle)
    //     {
    //         circle.radius *= 1.2f;
    //     }
    // }

}