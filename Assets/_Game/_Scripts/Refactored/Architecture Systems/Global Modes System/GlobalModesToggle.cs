using StateMachine.StateMachineSystems;
using UnityEngine;
using UnityEngine.Serialization;

public class GlobalModesToggle
{
    private StateMachine<EmptyContext> _statesGame;
    public GlobalModesToggle()
    {
        _statesGame = new StateMachineBuilder<EmptyContext>()
            .AddState(new Global_BuildMode())
            .AddState(new Global_MenuMode())
            .AddState(new Global_PauseMode())
            .AddState(new Global_PlayMode())
            .Build();
        
        // ActivateMenuMode();
    }

    public void ActivateBuildMode()
    {
        _statesGame.SwitchToState<Global_BuildMode>(new EmptyContext());
    }
    
    public void ActivatePlayMode()
    {
        _statesGame.SwitchToState<Global_PlayMode>(new EmptyContext());
    }
    
    public void ActivateMenuMode()
    {
        _statesGame.SwitchToState<Global_MenuMode>(new EmptyContext());
    }

    public void TogglePauseMode()//пауза может быть поверх других состояний
    {
        
        if (_statesGame.IsStateActive(_statesGame.GetStateFromRegistry<Global_PauseMode>()))
        {
            _statesGame.SetStateActive<Global_PauseMode>(false, new EmptyContext());
        }
        else
        {
            _statesGame.SetStateActive<Global_PauseMode>(true, new EmptyContext());
        }
    }
    public void DeactivatePauseMode()
    {
        _statesGame.SetStateActive<Global_PauseMode>(false, new EmptyContext());
    }
    
}