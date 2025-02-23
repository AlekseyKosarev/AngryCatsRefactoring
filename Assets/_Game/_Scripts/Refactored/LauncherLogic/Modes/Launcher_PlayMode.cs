using UnityEngine;

public class Launcher_PlayMode: BaseState<Launcher_Context>
{
    public override void Init(Launcher_Context context)
    {
        //TODO чтобы делать рестарт правильно, нужно сбрасывать все иниты у стейт машин(ResetState();) 
    }
    public override void EnterState(Launcher_Context context)
    {
        base.EnterState(context);
        Root.Instance.LAUNCHER_PlayMode = true;
        context.InputHandler.InputEnabled = true; // Включаем инпут
        context.Physics.ResumePhysics(); // Включаем физику
        context.View.EnableEffects(); // Включаем визуальные эффекты
        
        context.InputHandler.OnLaunchStart += context.Magazine.Launch;
        // ResetState();
        // Debug.Log("LAUNCHER PlayMode enter");
    }

    public override void ExitState(Launcher_Context context)
    {
        Root.Instance.LAUNCHER_PlayMode = false;
        context.InputHandler.OnLaunchStart -= context.Magazine.Launch;
        // Debug.Log("LAUNCHER PlayMode exit");
    }

    public override void UpdateState(Launcher_Context context)
    {
        
        
        // Логика обновления в режиме игры
        if (context.InputHandler.IsDragging)
        {
            if (context.Magazine.launcherIsEmpty) return;
            if (context.Magazine.launcherIsReady == false) return;
            context.View.DrawRope(context.InputHandler.GetStartPoint(), context.InputHandler.CalculateEndPoint());

            var velocity = context.Magazine.launchForce;
            var mass = context.Magazine.GetMassProjectile();
            context.View.DrawTrajectory(context.InputHandler.GetStartPoint(), context.InputHandler.GetDirection(), velocity, mass);
        }
        else
        {
            context.View.ClearRope();
            context.View.ClearTrajectory();
        }
        
    }
}