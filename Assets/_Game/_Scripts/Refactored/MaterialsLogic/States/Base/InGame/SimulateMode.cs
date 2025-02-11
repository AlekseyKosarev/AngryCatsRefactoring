using UnityEngine;

public class SimulateMode: BaseState<MaterialContext>
{
    public override void Init()
    {
        throw new System.NotImplementedException();
    }

    public override void EnterState(MaterialContext context)
    {
        Debug.Log("SimulateMode enter");
        //вот тут по контексту могу получить ссылку на все необходимые компоненты
        
        //включение физики
        context.Rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public override void ExitState(MaterialContext context)
    {
        //выключение физики
        context.Rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public override void UpdateState(MaterialContext context)
    {
        //ничего
    }
}