using _Project.System.StateMachine.StateMachine;
using UnityEngine;

public class InputModeToggle: MonoBehaviour
{
    private StateMachine<GameInputSystem_Actions> _inputModes;

    private GameInputSystem_Actions inputActions;
    
    private void Start()
    {
        Init();
    }
    private void Init()
    {
        inputActions = Root.Instance.InputActions;

        _inputModes = new StateMachineBuilder<GameInputSystem_Actions>()//TODO refactor this - когда будет добавлена возможность добавить список состояний! 
            .AddState(new InputBuildMode())
            .AddState(new InputGameMode())
            .AddState(new InputGlobalMode())
            .Build();
        
        EnableGlobalMode();
        EnableBuildMode();
    }

    public void EnableBuildMode()
    {
        _inputModes.SetStateActive<InputBuildMode>(true, inputActions);
    }

    public void EnableGameMode()
    {
        _inputModes.SetStateActive<InputGameMode>(true, inputActions);
    }
    public void EnableGlobalMode()
    {
        _inputModes.SetStateActive<InputGlobalMode>(true, inputActions);
    }
    public void DisableAllModes()//TODO refactor this - когда будет вынесен deactivateAllStates 
    {
        _inputModes.SetStateActive<InputBuildMode>(false, inputActions);
        _inputModes.SetStateActive<InputGameMode>(false, inputActions);
    }
}