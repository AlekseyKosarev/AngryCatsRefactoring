using UnityEngine;

public class FlyState: BaseState<Projectile_Context>
{
    float lifeTimeDef = 2f;
    float lifeTime = 2f;
    public override void Init(Projectile_Context context)
    {
        lifeTime = lifeTimeDef;
    }

    public override void EnterState(Projectile_Context context)
    {
        // Debug.Log("Fly Projectile");
        context.Physics.On();
    }
    public override void ExitState(Projectile_Context context)
    {
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