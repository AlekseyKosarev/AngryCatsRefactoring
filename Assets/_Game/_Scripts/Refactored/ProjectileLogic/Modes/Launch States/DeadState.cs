using DG.Tweening;
using UnityEngine;

public class DeadState: BaseState<Projectile_Context>
{
    private Timer _timerDeadTime;
    public override void Init(Projectile_Context context)
    {
        _timerDeadTime = new Timer(Root.Instance.DamageSettings.deadDurationDefault);
    }

    public override void EnterState(Projectile_Context context)
    {
        base.EnterState(context);
        
        // context.Physics.OnRigidBody();
        context.View.SetProjectileSpriteDead();
        _timerDeadTime.Start(() => Dead(context));
    }
    public override void ExitState(Projectile_Context context)
    {
    }

    public override void UpdateState(Projectile_Context context)
    {
        _timerDeadTime.Update(Time.deltaTime);
    }
    private void Dead(Projectile_Context context)
    {
        context.View.DeadAnimation();
        context.Physics.OffRigidbodyNoSave();
        context.Physics.ColliderSetActive(false);
        // Debug.Log("Таймер завершен!");
    }
}