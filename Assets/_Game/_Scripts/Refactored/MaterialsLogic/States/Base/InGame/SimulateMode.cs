using UnityEngine;

public class SimulateMode: BaseState<MaterialContext>
{
    public override void Init(MaterialContext context)
    {
        //ничего
    }

    public override void EnterState(MaterialContext context)
    {
        Debug.Log("SimulateMode enter");
        //вот тут по контексту могу получить ссылку на все необходимые компоненты
        
        //включение физики
        context.Rb.bodyType = RigidbodyType2D.Dynamic;//TODO сделать функцию для включение/выключения физики
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