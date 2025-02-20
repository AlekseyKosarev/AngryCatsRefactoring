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

    public void OnPauseToggle(InputAction.CallbackContext context)
    {
        if(context.performed)
            Root.Instance.globalModesToggle.TogglePauseMode();
            // PausableRegistry.TogglePauseMode();
    }
    public void OnBuildToggle(InputAction.CallbackContext context)
    {
        if(context.performed)
           Root.Instance.globalModesToggle.ActivateBuildMode();
            // BuildableRegistry.ToggleBuildMode();
    }
    public void OnPlayToggle(InputAction.CallbackContext context)
    {
        if(context.performed)
            Root.Instance.globalModesToggle.ActivatePlayMode();
            // PlayableRegistry.TogglePlayMode();
    }
}