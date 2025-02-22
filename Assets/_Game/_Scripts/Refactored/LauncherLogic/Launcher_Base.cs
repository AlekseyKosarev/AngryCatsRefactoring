using System;
using StateMachine.StateMachineSystems;
using UnityEngine;

public class Launcher_Base : MonoBehaviour, IPausable, IBuildable, IPlayable
{
    public Transform pointOfLaunch;
    
    private StateMachine<Launcher_Context> _states;
    
    private Launcher_Context _context;
    
    private Launcher_View _view;
    private Launcher_Physics _physics;
    private Launcher_InputHandler _inputHandler;
    private Launcher_Magazine _magazine;

    private void Init()
    {
        _view = GetComponent<Launcher_View>();
        _physics = GetComponent<Launcher_Physics>();
        _inputHandler = GetComponent<Launcher_InputHandler>();
        _magazine = GetComponent<Launcher_Magazine>();
        
        _context = new Launcher_Context(_view, _physics, _inputHandler, _magazine, pointOfLaunch);
    }
    private void Start()
    {
        Init();
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