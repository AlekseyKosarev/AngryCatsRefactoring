using System;
using StateMachine.StateMachineSystems;
using UnityEngine;

public class Launcher_Base : MonoBehaviour, IPausable, IBuildable, IPlayable
{
    private StateMachine<Launcher_Context> _states;
    
    private Launcher_Context _context;
    
    private Launcher_View _view;
    private Launcher_PhysicsController _physicsController;
    private Launcher_InputHandler _inputHandler;

    private void Start()
    {
        _view = GetComponent<Launcher_View>();
        _physicsController = GetComponent<Launcher_PhysicsController>();
        _inputHandler = GetComponent<Launcher_InputHandler>();
        
        _context = new Launcher_Context(_view, _physicsController, _inputHandler);
        
        _states = new StateMachineBuilder<Launcher_Context>()
            .AddState(new Launcher_BuildMode())
            .AddState(new Launcher_PauseMode())
            .AddState(new Launcher_PlayMode())
            .Build();
    }

    private void Update()
    {
        _states.Update(_context);
    }

    public void PauseMode_Enable()
    {
        _states.SaveCurrentStatesToPrevious();
        _states.SwitchToState<Launcher_PauseMode>(_context);
    }

    public void PauseMode_Disable()
    {
        _states.SetStateActive<Launcher_PauseMode>(false, _context);
        _states.ActivatePreviousStates(_context);
    }

    public void BuildMode_Enable()
    {
        _states.SwitchToState<Launcher_BuildMode>(_context);
    }

    public void BuildMode_Disable()
    {
        _states.SetStateActive<Launcher_BuildMode>(false, _context);
    }

    public void PlayMode_Enable()
    {
        _states.SwitchToState<Launcher_PlayMode>(_context);
    }

    public void PlayMode_Disable()
    {
        _states.SetStateActive<Launcher_PlayMode>(false, _context);
    }
}