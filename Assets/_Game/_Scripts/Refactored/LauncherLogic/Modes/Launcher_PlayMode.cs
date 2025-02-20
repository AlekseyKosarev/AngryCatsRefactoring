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
            context.View.DrawTrajectory(context.InputHandler.StartPosition, context.InputHandler.EndPosition);
        }
        else
        {
            context.View.ClearTrajectory();
        }
    }
}