public class Launcher_PauseMode: BaseState<Launcher_Context>
{
    public override void Init(Launcher_Context context)
    {
    }
    public override void EnterState(Launcher_Context context)
    {
        Root.Instance.LAUNCHER_PauseMode = true;
        context.InputHandler.Input_Disable(); // Отключаем инпут
        context.PhysicsController.PausePhysics(); // Приостанавливаем физику
        context.View.DisableEffects(); // Отключаем визуальные эффекты
    }

    public override void ExitState(Launcher_Context context)
    {
        Root.Instance.LAUNCHER_PauseMode = false;
    }

    public override void UpdateState(Launcher_Context context)
    {
    }
}