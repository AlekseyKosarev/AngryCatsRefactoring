using StateMachine.StateMachineSystems;
using UnityEngine;

public class GlobalModesToggle: MonoBehaviour
{
    public BaseMaterial materialPrefab;//pausable
    
    private StateMachine<EmptyContext> _statesGame;
    private void Init()
    {
        _statesGame = new StateMachineBuilder<EmptyContext>()
            .AddState(new Global_BuildMode())
            .AddState(new Global_MenuMode())
            .AddState(new Global_PauseMode())
            .AddState(new Global_PlayMode())
            .Build();
    }
    private void Update()
    {
        //switch pause|game - space
        if (Input.GetKeyDown(KeyCode.P))
        {
            materialPrefab.PauseMode_Enable();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            materialPrefab.EnterPlayMode();
        }

        // //build mode
        // if (Input.GetKeyDown(KeyCode.B))
        // {
        //     materialPrefab.EnterBuildMode();
        // }
        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     materialPrefab.ExitBuildMode();
        // }
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

    public void ActivatePauseMode()//пауза может быть поверх других состояний
    {
        _statesGame.SetStateActive<Global_PauseMode>(true, new EmptyContext());
    }
    public void DeactivatePauseMode()
    {
        _statesGame.SetStateActive<Global_PauseMode>(false, new EmptyContext());
    }
    
}