using UnityEngine;
using UnityEngine.InputSystem;

public class Input_MenuMode: BaseState<InputActionMap>
{
    private InputAction closeAction;
    private InputAction backAction;
    //клавиши, которые будут работать в меню - это глобальные клавиши доступные из всех режимов(по возможности)
    //примеры: Escape - отмена/возврат в меню
    
    //хотя я тут подумал - в каждом режиме свой интерфейс
    //(да будут одинаковые кнопки - (назад в меню) - но логика думаю будет отличаться)
    //к тому же я хочу иметь возможность переопределить эти клавиши в каждом режиме - esc - отмена/возвратВменю/пауза/выходИЗпаузы - 
    public override void Init(InputActionMap context)
    {
        context.FindAction("Click");
    }

    public override void EnterState(InputActionMap context)
    {
        base.EnterState(context);
        
        Root.Instance.Input_MenuMode = true;
        
        // Подписка на действия
        closeAction.performed += OnClosePerformed;
        backAction.performed += OnBackPerformed;
    }

    public override void ExitState(InputActionMap context)
    {
        Root.Instance.Input_MenuMode = true;

        // Отписка от действий
        closeAction.performed -= OnClosePerformed;
        backAction.performed -= OnBackPerformed;
    }

    public override void UpdateState(InputActionMap context)
    {
        //Nothing - its NOT call 
    }

    private void OnClosePerformed(InputAction.CallbackContext context)
    {
        //Do something
    }

    private void OnBackPerformed(InputAction.CallbackContext context)
    {
        //Do something
    }
}