using System;
using StateMachine.StateMachineSystems;

public class Projectile_PlayMode: BaseState<Projectile_Context>
{
    private StateMachine<Projectile_Context> _states;

    public override void Init(Projectile_Context context)
    {
        
        _states = new StateMachineBuilder<Projectile_Context>()
            .AddState(new InMagazineState())
            .AddState(new ReadyState())
            .AddState(new FlyState())
            .AddState(new DeadState())
            .Build();
        
        // SwitchToInMagazineState(context);
    }
    public override void EnterState(Projectile_Context context)
    {
        base.EnterState(context);
        SwitchToInMagazineState(context);
    }
    public override void ExitState(Projectile_Context context)
    {
    }

    public override void UpdateState(Projectile_Context context)
    {
        context.PlayModeStates = this;
        _states.Update(context);
    }
    public void SwitchToInMagazineState(Projectile_Context context)
    {
        context.PlayModeStates = this;
        _states.SwitchToState<InMagazineState>(context);
    }
    public void SwitchToFlyState(Projectile_Context context) 
    {
        context.PlayModeStates = this;
        _states.SwitchToState<FlyState>(context);
    }
    public void SwitchToReadyState(Projectile_Context context) 
    {
        context.PlayModeStates = this;
        _states.SwitchToState<ReadyState>(context);
    }
    public void SwitchToDeadState(Projectile_Context context) 
    {
        context.PlayModeStates = this;
        _states.SwitchToState<DeadState>(context);
    }
    

}