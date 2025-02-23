using System;
using UnityEngine;

public class ReadyState: BaseState<Projectile_Context>
{
    private Action<Vector2, float> _launchHandler;
    public override void Init(Projectile_Context context)
    {
    }

    public override void EnterState(Projectile_Context context)
    {
        // Debug.Log("Ready Projectile");
        context.Physics.OffCollider();
        _launchHandler = (dir, force) => Launch(dir, force, context);
        context.LaunchHandler.OnLaunch += _launchHandler;
    }
    public override void ExitState(Projectile_Context context)
    {
        context.Physics.OnCollider();
        context.LaunchHandler.OnLaunch -= _launchHandler;
    }

    public override void UpdateState(Projectile_Context context)
    {
    }
    
    private void Launch(Vector2 dir, float force, Projectile_Context context)
    {
        if(context.IsLaunched) return;
        
        context.IsLaunched = true;
        
        context.PlayModeStates.SwitchToFlyState(context);
        context.Physics.Launch(dir, force);
    }
}