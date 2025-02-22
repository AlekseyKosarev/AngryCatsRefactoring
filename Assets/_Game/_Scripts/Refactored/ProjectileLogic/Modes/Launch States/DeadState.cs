using UnityEngine;

public class DeadState: BaseState<Projectile_Context>
{
    public override void Init(Projectile_Context context)
    {
        
    }

    public override void EnterState(Projectile_Context context)
    {
        context.View.SetProjectileSpriteDead();
    }
    public override void ExitState(Projectile_Context context)
    {
    }

    public override void UpdateState(Projectile_Context context)
    {
    }
}