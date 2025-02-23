using System;
using UnityEngine;

public class InMagazineState : BaseState<Projectile_Context>
{
    private Action readyAction;
    public override void Init(Projectile_Context context)
    {
        
    }

    public override void EnterState(Projectile_Context context)
    {
        context.View.SetProjectileSpriteDef();
        Debug.Log("InMagazine Projectile");
        readyAction = () => context.PlayModeStates.SwitchToReadyState(context);
        context.LaunchHandler.OnReady += readyAction;
    }
    public override void ExitState(Projectile_Context context)
    {
        if (context.LaunchHandler == null || context.PlayModeStates == null)
        {
            Debug.LogError("Context or its dependencies are not initialized.");
            return;
        }
        context.LaunchHandler.OnReady -= readyAction;
    }

    public override void UpdateState(Projectile_Context context)
    {
    }
}