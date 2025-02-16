using UnityEngine;
using UnityEngine.InputSystem;

public class Input_PlayMode: BaseState<GameInputSystem_Actions>, GameInputSystem_Actions.IPlayModeActions
{
    public override void Init(GameInputSystem_Actions context)
    {
    }

    public override void EnterState(GameInputSystem_Actions context)
    {
        base.EnterState(context);
        Root.Instance.Input_PlayMode = true;
        
        context.PlayMode.Enable();
        context.PlayMode.SetCallbacks(this);
    }

    public override void ExitState(GameInputSystem_Actions context)
    {
        Root.Instance.Input_PlayMode = false;
        
        context.PlayMode.Disable();
        context.PlayMode.RemoveCallbacks(this);
    }

    public override void UpdateState(GameInputSystem_Actions context)
    {
        //Nothing - its NOT call 
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        Debug.Log("Playmode Click "+ context.phase);
        Root.Instance.inputLogic.ClickTo(context.phase);
    }
}