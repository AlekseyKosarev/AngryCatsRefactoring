using UnityEngine;
using UnityEngine.InputSystem;

public class Input_BuildMode: BaseState<GameInputSystem_Actions>, GameInputSystem_Actions.IBuildModeActions
{
    public override void Init(GameInputSystem_Actions context)
    {
    }

    public override void EnterState(GameInputSystem_Actions context)
    {
        base.EnterState(context);
        Root.Instance.Input_BuildMode = true;
        
        context.BuildMode.Enable();
        context.BuildMode.SetCallbacks(this);
    }

    public override void ExitState(GameInputSystem_Actions context)
    {
        Root.Instance.Input_BuildMode = false;
        
        context.BuildMode.Disable();
        context.BuildMode.RemoveCallbacks(this);
    }

    public override void UpdateState(GameInputSystem_Actions context)
    {
        //Nothing - its NOT call 
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        Root.Instance.inputLogic.ClickTo(context.phase);
    }
}