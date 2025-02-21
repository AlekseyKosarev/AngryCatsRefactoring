using UnityEngine;

public class Global_BuildMode: BaseState<EmptyContext>
{
    public override void Init(EmptyContext context)
    {
        //nothing
    }

    public override void EnterState(EmptyContext context)
    {
        Root.Instance.Global_BuildMode = true;
        //enter build mode
        
        // - включается меню строительного режима
        // - инпут соответственно
        // - звуки музыка
        // - спавнер объектов переходит в активный режим
        // - спавнер включает режим строительства у всех объектов
        Root.Instance.BuildableRegistry.EnterBuildMode();
        // Root.Instance.PausableRegistry.EnterBuildMode();
        Root.Instance.PlayableRegistry.ExitPlayMode();
        Root.Instance.uiScreenSwitcher.SwitchToBuildScreen();
    }

    public override void ExitState(EmptyContext context)
    {
        Root.Instance.Global_BuildMode = false;
        //exit build mode
        // - все что зависит от строительного режима выключается
        Root.Instance.BuildableRegistry.ExitBuildMode();
    }

    public override void UpdateState(EmptyContext context)
    {
        //nothing
    }
}