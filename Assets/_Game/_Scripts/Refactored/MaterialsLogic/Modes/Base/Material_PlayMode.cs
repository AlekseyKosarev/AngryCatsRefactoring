
using System;
using UnityEngine;

public class Material_PlayMode: BaseState<Material_Context>
{
    private Action<float> OnTakeDamage;
    private Action OnDead;
    public override void Init(Material_Context context)
    {
        //ничего
    }

    public override void EnterState(Material_Context context)
    {
        Root.Instance.Material_PlayMode = true;
        
        //вот тут по контексту могу получить ссылку на все необходимые компоненты
        
        //включение физики
        context.Physics.OnRigidBody();
        OnTakeDamage = dmg => TakeDamage(dmg, context);
        OnDead = () => Dead(context);
        
        context.DamageHandler.OnTryTakeDamage += OnTakeDamage;
        context.DamageHandler.OnDead += OnDead;
    }

    public override void ExitState(Material_Context context)
    {
        Root.Instance.Material_PlayMode = false;
        //выключение физики
        // context.Physics.Off_SaveVelocity();//TODO 
        context.DamageHandler.OnTryTakeDamage -= OnTakeDamage;
        context.DamageHandler.OnDead -= OnDead;
    }

    public override void UpdateState(Material_Context context)
    {
        //ничего
    }

    private void TakeDamage(float damage, Material_Context context)
    {
        
        context.DamageHandler.TakeDamage(damage);
        
        var countPart = context.View.GetCountSpriteParts();
        var currentPart = context.DamageHandler.GetCurrentPart(countPart);
        // Debug.Log("Take dmg = " + damage + " currentPart = " + currentPart);
        context.View.SetSpritePartByIndex(currentPart);
    }

    private void Dead(Material_Context context)
    {
        context.View.DeadView();
        context.Physics.OffRigidbodyNoSave();
        context.Physics.ColliderSetActive(false);
    }
}