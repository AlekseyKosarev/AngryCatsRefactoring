using UnityEngine;
using UnityEngine.InputSystem;

public class Input_GlobalMode: BaseState<GameInputSystem_Actions>
{
    private InputAction _pauseMode_enter_btn;
    private InputAction _buildMode_enter_btn;
    private InputAction _playMode_enter_btn;
    
    private InputAction _pauseMode_exit_btn;
    private InputAction _buildMode_exit_btn;
    private InputAction _playMode_exit_btn;
    public override void Init(GameInputSystem_Actions context)
    {
        Debug.Log("INPUT GlobalMode INIT");
        _pauseMode_enter_btn = context.GlobalMode.PauseEnter;
        _buildMode_enter_btn = context.GlobalMode.BuildEnter;
        _playMode_enter_btn = context.GlobalMode.GameEnter;
        
        _pauseMode_exit_btn = context.GlobalMode.PauseExit;
        _buildMode_exit_btn = context.GlobalMode.BuildExit;
        _playMode_exit_btn = context.GlobalMode.GameExit;
    }

    public override void EnterState(GameInputSystem_Actions context)
    {
        base.EnterState(context);
        Root.Instance.Input_GlobalMode = true;
        
        context.GlobalMode.Enable();
        
        // Подписка на действия
        _pauseMode_enter_btn.performed += OnPauseMode_Enter;
        _buildMode_enter_btn.performed += OnBuildMode_Enter;
        _playMode_enter_btn.performed += OnPlayMode_Enter;
        
        _pauseMode_exit_btn.performed += OnPauseMode_Exit;
        _buildMode_exit_btn.performed += OnBuildMode_Exit;
        _playMode_exit_btn.performed += OnPlayMode_Exit;
    }
    public override void ExitState(GameInputSystem_Actions context)
    {
        Root.Instance.Input_GlobalMode = false;
        
        context.GlobalMode.Disable();
        
        // Отписка от действий
        _pauseMode_enter_btn.performed -= OnPauseMode_Enter;
        _buildMode_enter_btn.performed -= OnBuildMode_Enter;
        _playMode_enter_btn.performed -= OnPlayMode_Enter;
        
        _pauseMode_exit_btn.performed -= OnPauseMode_Exit;
        _buildMode_exit_btn.performed -= OnBuildMode_Exit;
        _playMode_exit_btn.performed -= OnPlayMode_Exit;
    }

    public override void UpdateState(GameInputSystem_Actions context)
    {
        //nothing
    }
    private void OnPauseMode_Enter(InputAction.CallbackContext context)
    {
        Debug.Log("Pause enter Click");
        Root.Instance.PausableRegistry.EnterPauseMode();
    }
    private void OnPauseMode_Exit(InputAction.CallbackContext context)
    {
        Debug.Log("Pause exit Click");
        Root.Instance.PausableRegistry.ExitPauseMode();
    }
    private void OnBuildMode_Enter(InputAction.CallbackContext context)
    {
        Root.Instance.BuildableRegistry.EnterBuildMode();
    }
    private void OnBuildMode_Exit(InputAction.CallbackContext context)
    {
        Root.Instance.BuildableRegistry.ExitBuildMode();
    }
    private void OnPlayMode_Enter(InputAction.CallbackContext context)
    {
        Root.Instance.PlayableRegistry.EnterPlayMode();
    }
    private void OnPlayMode_Exit(InputAction.CallbackContext context)
    {
        Root.Instance.PlayableRegistry.ExitPlayMode();        
    }
    
}