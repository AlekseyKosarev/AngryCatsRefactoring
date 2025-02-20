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
        context.Physics.SetPlayMode();
    }

    public override void ExitState(Material_Context context)
    {
        Root.Instance.Material_PlayMode = false;
        //выключение физики
        // context.Physics.Off_SaveVelocity();//TODO 
    }

    public override void UpdateState(Material_Context context)
    {
        //ничего
    }
}