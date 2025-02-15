using UnityEngine;
using UnityEngine.InputSystem;

public class Input_BuildMode: BaseState<GameInputSystem_Actions>
{
    private InputAction clickAction;
    // private InputAction dragAction;
    
    
    public override void Init(GameInputSystem_Actions context)
    {
        Debug.Log("INPUT BuildMode INIT");
        clickAction = context.BuildMode.Click;
        // dragAction = context.FindAction("Drag");
    }

    public override void EnterState(GameInputSystem_Actions context)
    {
        base.EnterState(context);
        Root.Instance.Input_BuildMode = true;
        Debug.Log("INPUT BuildMode ENTER");
        // Подписка на действия
        context.BuildMode.Enable();
        clickAction.started += OnClickDowned;
        clickAction.performed += OnClickPerformed;
        clickAction.canceled += OnClickCanceled;
    }

    public override void ExitState(GameInputSystem_Actions context)
    {
        Root.Instance.Input_BuildMode = false;
        Debug.Log("INPUT BuildMode EXIT");
        // Отписка от действий
        context.BuildMode.Disable();
        clickAction.started -= OnClickDowned;
        clickAction.performed -= OnClickPerformed;
        clickAction.canceled -= OnClickCanceled;
    }

    public override void UpdateState(GameInputSystem_Actions context)
    {
        //Nothing - its NOT call 
    }

    private void OnClickDowned(InputAction.CallbackContext context)
    {
        Root.Instance.inputLogic.ClickTo(ClickPart.Down);
    }
    private void OnClickPerformed(InputAction.CallbackContext context)
    {
        Root.Instance.inputLogic.ClickTo(ClickPart.Performed);
    }
    private void OnClickCanceled(InputAction.CallbackContext context)
    {
        Root.Instance.inputLogic.ClickTo(ClickPart.Up);
    }
}