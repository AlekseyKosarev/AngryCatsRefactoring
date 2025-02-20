using UnityEngine;

public class Material_PauseMode: BaseState<Material_Context>
{
    public override void Init(Material_Context context)
    {
        //nothing
    }

    public override void EnterState(Material_Context context)
    {
        Root.Instance.Material_PauseMode = true;
        
        context.View.StopActiveEffects();
        context.Physics.Off_SaveVelocity();
    }
    public override void ExitState(Material_Context context)
    {
        Root.Instance.Material_PauseMode = false;
    }

    public override void UpdateState(Material_Context context)
    {
        
    }
}