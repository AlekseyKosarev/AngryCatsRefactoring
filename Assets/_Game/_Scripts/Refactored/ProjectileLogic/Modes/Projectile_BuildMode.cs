public class Projectile_BuildMode: BaseState<Projectile_Context>
{
    public override void Init(Projectile_Context context)
    {
    }
    public override void EnterState(Projectile_Context context)
    {
        context.Physics.OffClear();
        context.View.SetProjectileSpriteDef();
    }
    public override void ExitState(Projectile_Context context)
    {
        
    }

    public override void UpdateState(Projectile_Context context)
    {
        
    }
}