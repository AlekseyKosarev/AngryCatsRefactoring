public class Global_PauseMode: BaseState<EmptyContext>
{
    public override void Init(EmptyContext context)
    {
        //nothing
    }

    public override void EnterState(EmptyContext context)
    {
        Root.Instance.Global_PauseMode = true;
        //enter pause mode
        // - меню паузы
        // - у всех IPausable объектов вызывается EnterPauseMode()
        // - пока думаю так - это будет доп состояние, которое может работать поверх других
        // - соответственно - при выключении паузы объекты должны будут продолжить выполнять активные состояния, которые были - без перехода в них!!!
        
        Root.Instance.PausableRegistry.EnterPauseMode();
    }

    public override void ExitState(EmptyContext context)
    {
        Root.Instance.Global_PauseMode = false;
        //exit pause mode
        // - меню паузы выключается
        // - у всех IPausable объектов вызывается ExitPauseMode()
        Root.Instance.PausableRegistry.ExitPauseMode();
    }

    public override void UpdateState(EmptyContext context)
    {
        //nothing
    }
}