using UnityEngine.InputSystem;

public class InputGlobalMode: BaseState<GameInputSystem_Actions>
{
    private InputAction pauseModeToggle;
    private InputAction buildModeToggle;
    private InputAction gameModeToggle;
    public override void Init(GameInputSystem_Actions context)
    {
        GameInputSystem_Actions inputActions = new GameInputSystem_Actions();
        pauseModeToggle = inputActions.GlobalMode.PauseToggle;
        buildModeToggle = inputActions.GlobalMode.BuildToggle;
        gameModeToggle = inputActions.GlobalMode.GameToggle;
    }

    public override void EnterState(GameInputSystem_Actions context)
    {
        base.EnterState(context);
        context.GlobalMode.Enable();

        // Подписка на действия
        pauseModeToggle.performed += OnPauseModeTogglePerformed;
        buildModeToggle.performed += OnBuildModeTogglePerformed;
        gameModeToggle.performed += OnGameModeTogglePerformed;
    }
    public override void ExitState(GameInputSystem_Actions context)
    {
        context.GlobalMode.Enable();

        // Отписка от действий
        pauseModeToggle.performed -= OnPauseModeTogglePerformed;
        buildModeToggle.performed -= OnBuildModeTogglePerformed;
        gameModeToggle.performed -= OnGameModeTogglePerformed;
    }

    public override void UpdateState(GameInputSystem_Actions context)
    {
        throw new System.NotImplementedException();
    }
    private void OnPauseModeTogglePerformed(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
    private void OnBuildModeTogglePerformed(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
    private void OnGameModeTogglePerformed(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}