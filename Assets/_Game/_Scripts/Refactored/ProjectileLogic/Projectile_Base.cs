
using StateMachine.StateMachineSystems;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Projectile_Physics))]
[RequireComponent(typeof(Projectile_View))]
[RequireComponent(typeof(Projectile_InputHandler))]
[RequireComponent(typeof(Projectile_Launch))]
public class Projectile_Base: MonoBehaviour, IPausable, IBuildable, IPlayable
{
    private StateMachine<Projectile_Context> _states;
    private Projectile_Context _context;

    private Rigidbody2D rb;
    private Projectile_Physics physics;
    private Projectile_View view;
    private Projectile_InputHandler inputHandler;
    private Projectile_Launch launchHandler;
    
    public void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        physics = GetComponent<Projectile_Physics>();
        view = GetComponent<Projectile_View>();
        inputHandler = GetComponent<Projectile_InputHandler>();
        launchHandler = GetComponent<Projectile_Launch>();
        
        _context = new Projectile_Context(rb, transform, view, inputHandler, physics, launchHandler);
    }

    public void InitStateMachine()
    {
        _states = new StateMachineBuilder<Projectile_Context>()
            .AddState(new Projectile_PlayMode())
            .AddState(new Projectile_BuildMode())
            .AddState(new Projectile_PauseMode())
            .Build();
    }
    private void Start()
    {
        Init();
        InitStateMachine();
    }
    private void Update()
    {
        _states.Update(_context);
    }

    void RestartPlaying()
    {
        // Debug.Log("RestartPlaying Projectile");
        var playMode = _states.GetStateFromRegistry<Projectile_PlayMode>() as BaseState<Projectile_Context>;
        playMode?.ResetState();
        _context.LaunchHandler.Restart();
    }
    public void PauseMode_Enable()
    {
        launchHandler.PauseTween();
        _states.SaveCurrentStatesToPrevious();
        _states.SwitchToState<Projectile_PauseMode>(_context);
    }

    public void PauseMode_Disable()
    {
        launchHandler.ResumeTween();
        _states.ActivatePreviousStates(_context);
        _states.SetStateActive<Projectile_PauseMode>(false, _context);
    }

    public void BuildMode_Enable()
    {
        RestartPlaying();
        _states.SwitchToState<Projectile_BuildMode>(_context);
    }

    public void BuildMode_Disable()
    {
        // _states.DeactivateAllStates(_context);
        _states.SetStateActive<Projectile_BuildMode>(false, _context);
    }

    public void PlayMode_Enable()
    {
        RestartPlaying();
        _states.SwitchToState<Projectile_PlayMode>(_context);
    }

    public void PlayMode_Disable()
    {
        RestartPlaying();
        // _states.DeactivateAllStates(_context);
        _states.SetStateActive<Projectile_PlayMode>(false, _context);
    }
}