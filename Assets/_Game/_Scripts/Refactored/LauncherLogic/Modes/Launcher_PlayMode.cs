public class Launcher_PlayMode: BaseState<Launcher_Context>
{
    public override void Init(Launcher_Context context)
    {
    }
    public override void EnterState(Launcher_Context context)
    {
        Root.Instance.LAUNCHER_PlayMode = true;
        context.InputHandler.Input_Enable(); // Включаем инпут
        context.PhysicsController.ResumePhysics(); // Включаем физику
        context.View.EnableEffects(); // Включаем визуальные эффекты
    }

    public override void ExitState(Launcher_Context context)
    {
        Root.Instance.LAUNCHER_PlayMode = false;
        
    }

    public override void UpdateState(Launcher_Context context)
    {
        // Логика обновления в режиме игры
        if (context.InputHandler.IsDragging)
        {
            context.View.DrawRope(context.InputHandler.GetStartPoint(), context.InputHandler.CalculateEndPoint());

            var velocity = context.PhysicsController.velocityLaunch;
            var mass = context.PhysicsController.massProjectile;
            context.View.DrawTrajectory(context.InputHandler.GetStartPoint(), context.InputHandler.GetDirection(), velocity, mass);
        }
        else
        {
            context.View.ClearRope();
            context.View.ClearTrajectory();
        }
    }
}