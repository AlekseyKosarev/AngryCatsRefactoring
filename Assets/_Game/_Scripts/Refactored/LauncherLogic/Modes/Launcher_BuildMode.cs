public class Launcher_BuildMode: BaseState<Launcher_Context>
{
    public override void Init(Launcher_Context context)
    {
    }
    public override void EnterState(Launcher_Context context)
    {
        Root.Instance.LAUNCHER_BuildMode = true;
        context.InputHandler.Input_Disable(); // Отключаем инпут
        context.PhysicsController.PausePhysics(); // Отключаем физику
        context.View.DisableEffects(); // Отключаем визуальные эффекты
    }

    public override void ExitState(Launcher_Context context)
    {
        Root.Instance.LAUNCHER_BuildMode = false;
    }

    public override void UpdateState(Launcher_Context context)
    {
    }
}