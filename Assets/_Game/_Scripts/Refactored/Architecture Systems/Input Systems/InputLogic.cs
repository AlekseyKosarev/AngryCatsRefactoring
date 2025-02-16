using UnityEngine;
using UnityEngine.InputSystem;

public class InputLogic: MonoBehaviour
{
    private Camera mainCamera;
    private InputAction pointerPosition;
    private void Init()
    {
        mainCamera = Root.Instance.mainCamera;
        pointerPosition = Root.Instance.InputActions.GlobalMode.PointerPosition;
    }
    private void Start()
    {
        Init();
    }
    
    // private bool TryRayToPoint(Vector2 screenPosition, out RaycastHit hit)
    // {
    //     Ray ray = mainCamera.ScreenPointToRay(screenPosition);
    //     return Physics.Raycast(ray, out hit); // Возвращает true, если произошло столкновение
    // }
    private bool TryRayToPoint(Vector2 screenPosition, out RaycastHit2D hit)
    {
        Ray ray = mainCamera.ScreenPointToRay(screenPosition);
        // Cast the ray in the 2D world
        hit = Physics2D.Raycast(ray.origin, ray.direction);
        return hit.collider != null; // Returns true if there was a hit
    }
    private Vector2 GetMousePosition()
    {
        return pointerPosition.ReadValue<Vector2>();
    }

    public Vector2 GetMouseWorldPosition()
    {
        return mainCamera.ScreenToWorldPoint(GetMousePosition());
    }

    public void ClickTo(InputActionPhase clickPhase)
    {
        Vector2 screenPosition = GetMousePosition();
        if (TryRayToPoint(screenPosition, out RaycastHit2D hit))
        {
            IClickable clickable = hit.collider.GetComponent<IClickable>();
            if (clickable != null)
            {
                switch (clickPhase)// Вызываем метод OnClickDown или OnClickUp
                {
                    case InputActionPhase.Started:
                        clickable.OnClickDown();
                        break;
                    case InputActionPhase.Canceled:
                        clickable.OnClickUp();
                        break;
                    case InputActionPhase.Performed:
                        clickable.OnClickPerformed();
                        break;
                }
            }
        }
    }

    // public void DragTo(Vector3 worldPosition)
    // {
    //     // Логика для драга
    //     Debug.Log($"Dragging to {worldPosition}");
    // }
}