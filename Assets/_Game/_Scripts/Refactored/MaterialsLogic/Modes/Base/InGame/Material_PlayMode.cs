using UnityEngine;

public class Material_PlayMode: BaseState<MaterialContext>
{
    public override void Init(MaterialContext context)
    {
        //ничего
    }

    public override void EnterState(MaterialContext context)
    {
        Root.Instance.Material_PlayMode = true;
        
        //вот тут по контексту могу получить ссылку на все необходимые компоненты
        
        //включение физики
        context.Rb.bodyType = RigidbodyType2D.Dynamic;//TODO сделать функцию для включение/выключения физики
    }

    public override void ExitState(MaterialContext context)
    {
        Root.Instance.Material_PlayMode = false;
        //выключение физики
        context.Rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public override void UpdateState(MaterialContext context)
    {
        //ничего
    }
}