using UnityEngine.InputSystem;

public class InputGameMode: BaseState<GameInputSystem_Actions>
{
    private InputAction clickAction;
    private InputAction dragAction;
    
    
    public override void Init(GameInputSystem_Actions context)
    {
        clickAction = context.FindAction("Click");
        dragAction = context.FindAction("Drag");
    }

    public override void EnterState(GameInputSystem_Actions context)
    {
        base.EnterState(context);
        // Подписка на действия
        clickAction.performed += OnClickPerformed;
        dragAction.performed += OnDragPerformed;
    }

    public override void ExitState(GameInputSystem_Actions context)
    {
        // Отписка от действий
        clickAction.performed -= OnClickPerformed;
        dragAction.performed -= OnDragPerformed;
    }

    public override void UpdateState(GameInputSystem_Actions context)
    {
        //Nothing - its NOT call 
    }

    private void OnClickPerformed(InputAction.CallbackContext context)
    {
        //Do something
    }

    private void OnDragPerformed(InputAction.CallbackContext context)
    {
        //Do something
    }
}