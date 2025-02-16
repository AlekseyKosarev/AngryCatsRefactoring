using UnityEngine;
using UnityEngine.InputSystem;

public class Input_GlobalMode: BaseState<GameInputSystem_Actions>, GameInputSystem_Actions.IGlobalModeActions
{
    public override void Init(GameInputSystem_Actions context)
    {
        Debug.Log("INPUT GlobalMode INIT");
    }

    public override void EnterState(GameInputSystem_Actions context)
    {
        base.EnterState(context);
        Root.Instance.Input_GlobalMode = true;
        
        context.GlobalMode.Enable();
        context.GlobalMode.SetCallbacks(this);
    }
    public override void ExitState(GameInputSystem_Actions context)
    {
        Root.Instance.Input_GlobalMode = false;
        
        context.GlobalMode.Disable();
        context.GlobalMode.RemoveCallbacks(this);
    }

    public override void UpdateState(GameInputSystem_Actions context)
    {
        //nothing
    }

    public void OnPointerPosition(InputAction.CallbackContext context)
    {
        // throw new System.NotImplementedException();
    }

    public void OnPauseEnter(InputAction.CallbackContext context)
    {
        Debug.Log("Pause enter Click");
        Root.Instance.PausableRegistry.EnterPauseMode();
    }

    public void OnPauseExit(InputAction.CallbackContext context)
    {
        Debug.Log("Pause exit Click");
        Root.Instance.PausableRegistry.ExitPauseMode();
    }

    public void OnBuildEnter(InputAction.CallbackContext context)
    {
        Root.Instance.BuildableRegistry.EnterBuildMode();
    }

    public void OnBuildExit(InputAction.CallbackContext context)
    {
        Root.Instance.BuildableRegistry.ExitBuildMode();
    }

    public void OnPlayEnter(InputAction.CallbackContext context)
    {
        Root.Instance.PlayableRegistry.EnterPlayMode();
    }

    public void OnPlayExit(InputAction.CallbackContext context)
    {
        Root.Instance.PlayableRegistry.ExitPlayMode();
    }
}