public class Global_PlayMode: BaseState<EmptyContext>
{
    public override void Init(EmptyContext context)
    {
        //nothing
    }

    public override void EnterState(EmptyContext context)
    {
        Root.Instance.Global_PlayMode = true;
        //enter play mode
        // - включается меню режима игры
        // - инпут соответственно
        // - звуки музыка
        // - спавнер объектов переходит в активный режим
        // - спавнится лвл 
        // - спавнер включает режим игры у всех объектов
        Root.Instance.PlayableRegistry.EnterPlayMode();
        Root.Instance.BuildableRegistry.ExitBuildMode();
        Root.Instance.uiScreenSwitcher.SwitchToGameScreen();
    }

    public override void ExitState(EmptyContext context)
    {
        Root.Instance.Global_PlayMode = false;

        Root.Instance.PlayableRegistry.ExitPlayMode();
    }

    public override void UpdateState(EmptyContext context)
    {
        //nothing
    }
}