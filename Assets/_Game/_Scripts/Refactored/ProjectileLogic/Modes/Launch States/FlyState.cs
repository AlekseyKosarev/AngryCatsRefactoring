using UnityEngine;

public class FlyState: BaseState<Projectile_Context>
{
    float lifeTime = 0f;

    // private Action<IDamageable> OnDealDamage; 
    public override void Init(Projectile_Context context)
    {
        lifeTime = Root.Instance.DamageSettings.lifeTimeDefault;
    }

    public override void EnterState(Projectile_Context context)
    {
        base.EnterState(context);
        // Debug.Log("Fly Projectile");
        context.Physics.On();
        
        //sub on deal damage event

        // OnDealDamage = damageable => DealDamage(damageable, context);
        // context.Physics.OnTryDealDamage += OnDealDamage;
    }
    public override void ExitState(Projectile_Context context)
    {
        //unsub on deal damage event
        // context.Physics.OnTryDealDamage -= OnDealDamage;
    }

    public override void UpdateState(Projectile_Context context)
    {
        Flying(context);
    }
    
    private void Flying(Projectile_Context context)
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            
            Dead(context);
        }
        //check activate abillity
        //скрипт для способности заменяем(может быть пустым)
        //в скрипте есть методы - OnActivateAbility, OnDeactivateAbility, для паузы - OnStopAbility, OnLoadAbility
        //для способностей должен быть свой view и другое
        
        //преимущества
        //способности не зависят друг от друга
        //легко добавить новую способность
        //способность не сломает существующую логику
        
        //недостатки
        //нужно писать много однотипного кода - view и тд для каждой способности
        //
    }
    // private void DealDamage(IDamageable target, Projectile_Context context)
    // {
    //     var dmg = (int)(context.Physics.GetVelocityMagnitute() * Root.Instance.DamageSettings.damageModificator);
    //     if (dmg >= Root.Instance.DamageSettings.minFixDamage)
    //     {
    //         Debug.Log(dmg);
    //         target.TryTakeDamage(dmg);
    //     }
    //     //this run only when the projectile hits a target
    // }

    void Dead(Projectile_Context context)
    {
        if (context.LaunchHandler == null || context.PlayModeStates == null)
        {
            Debug.LogError("Context or its dependencies are not initialized.");
            return;
        }
        context.PlayModeStates.SwitchToDeadState(context);
    }
}