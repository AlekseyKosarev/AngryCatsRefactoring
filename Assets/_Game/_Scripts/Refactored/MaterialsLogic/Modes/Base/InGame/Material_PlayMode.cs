using UnityEngine;

public class Material_PlayMode: BaseState<Material_Context>
{
    public override void Init(Material_Context context)
    {
        //ничего
    }

    public override void EnterState(Material_Context context)
    {
        Root.Instance.Material_PlayMode = true;
        
        //вот тут по контексту могу получить ссылку на все необходимые компоненты
        
        //включение физики
        context.Rb.bodyType = RigidbodyType2D.Dynamic;//TODO сделать функцию для включение/выключения физики
    }

    public override void ExitState(Material_Context context)
    {
        Root.Instance.Material_PlayMode = false;
        //выключение физики
        context.Rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public override void UpdateState(Material_Context context)
    {
        //ничего
    }
}