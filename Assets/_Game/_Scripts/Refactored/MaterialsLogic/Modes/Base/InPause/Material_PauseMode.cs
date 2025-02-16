using UnityEngine;

public class Material_PauseMode: BaseState<MaterialContext>
{
    public override void Init(MaterialContext context)
    {
        //nothing
    }

    public override void EnterState(MaterialContext context)
    {
        Root.Instance.Material_PauseMode = true;
        
        context.View.StopActiveEffects();
    }
    public override void ExitState(MaterialContext context)
    {
        Root.Instance.Material_PauseMode = false;
    }

    public override void UpdateState(MaterialContext context)
    {
        
    }
}