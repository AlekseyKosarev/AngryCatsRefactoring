public class Projectile_BuildMode: BaseState<Projectile_Context>
{
    public override void Init(Projectile_Context context)
    {
    }
    public override void EnterState(Projectile_Context context)
    {
        context.Physics.OffRigidbodyNoSave();
        context.View.SetProjectileSpriteDef();
        context.View.ReviveAnimation();
    }
    public override void ExitState(Projectile_Context context)
    {
        
    }

    public override void UpdateState(Projectile_Context context)
    {
        
    }
}