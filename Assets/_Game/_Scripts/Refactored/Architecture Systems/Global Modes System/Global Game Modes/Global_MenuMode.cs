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