public class Projectile_PauseMode: BaseState<Projectile_Context>
{
    public override void Init(Projectile_Context context)
    {
    }
    public override void EnterState(Projectile_Context context)
    {
        context.Physics.OffWithSave();
    }
    public override void ExitState(Projectile_Context context)
    {
    }

    public override void UpdateState(Projectile_Context context)
    {
        
    }
}