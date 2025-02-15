using StateMachine.StateMachineSystems;
using UnityEngine;

public class InputModeToggle: MonoBehaviour, IPausable, IBuildable, IPlayable
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
            .AddState(new Input_BuildMode())
            .AddState(new Input_PlayMode())
            .AddState(new Input_GlobalMode())
            .Build();
        
        GlobalMode_Enable();
    }

    public void BuildMode_Enable() => _inputModes.SetStateActive<Input_BuildMode>(true, inputActions);

    public void BuildMode_Disable() => _inputModes.SetStateActive<Input_BuildMode>(false, inputActions);

    public void PlayMode_Enable() => _inputModes.SetStateActive<Input_PlayMode>(true, inputActions);

    public void PlayMode_Disable() => _inputModes.SetStateActive<Input_PlayMode>(false, inputActions);

    public void GlobalMode_Enable() => _inputModes.SetStateActive<Input_GlobalMode>(true, inputActions);
    public void GlobalMode_Disable() => _inputModes.SetStateActive<Input_GlobalMode>(false, inputActions);
    
    public void PauseMode_Enable()
    {
        _inputModes.SaveCurrentStatesToPrevious();
        _inputModes.SwitchToState<Input_GlobalMode>(inputActions);//TODO someone will need add PAUSE mode later 
    }

    public void PauseMode_Disable()
    {
        _inputModes.ActivatePreviousStates(inputActions);
    }
}