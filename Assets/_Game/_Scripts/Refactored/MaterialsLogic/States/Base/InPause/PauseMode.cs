using UnityEngine;

public class PauseMode: BaseState<MaterialContext>
{
    public override void Init(MaterialContext context)
    {
        //nothing
    }

    public override void EnterState(MaterialContext context)
    {
        Debug.Log("PauseMode enter");
        context.View.StopActiveEffects();
    }
    public override void ExitState(MaterialContext context)
    {
        
    }

    public override void UpdateState(MaterialContext context)
    {
        
    }
}