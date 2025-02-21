public class Global_MenuMode: BaseState<EmptyContext>
{
    public override void Init(EmptyContext context)
    {
        throw new System.NotImplementedException();
    }

    public override void EnterState(EmptyContext context)
    {
        Root.Instance.Global_MenuMode = true;
        
        Root.Instance.inputModeToggle.GlobalMode_Enable();
        Root.Instance.uiScreenSwitcher.SwitchToMenuScreen();
    }

    public override void ExitState(EmptyContext context)
    {
        Root.Instance.Global_MenuMode = false;
    }

    public override void UpdateState(EmptyContext context)
    {
        throw new System.NotImplementedException();
    }
}