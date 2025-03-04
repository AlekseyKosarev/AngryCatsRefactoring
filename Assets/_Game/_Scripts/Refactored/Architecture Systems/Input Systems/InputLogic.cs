using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputLogic: MonoBehaviour
{
    public LayerMask stopRaycastLayers;
    private Camera mainCamera;
    private InputAction pointerPosition;

    private List<IDraggable> draggingObjects;
    private void Init()
    {
        mainCamera = Root.Instance.mainCamera;
        pointerPosition = Root.Instance.InputActions.GlobalMode.PointerPosition;
        draggingObjects = new List<IDraggable>();
    }
    private void Start()
    {
        Init();
    }
    // private bool TryRayToPoint(Vector2 screenPosition, out RaycastHit2D hit)
    // {
    //     Ray ray = mainCamera.ScreenPointToRay(screenPosition);
    //     hit = Physics2D.Raycast(ray.origin, ray.direction);
    //     
    //     return hit.collider != null; 
    // }
    
    private bool TryRayToPoint(Vector2 screenPosition, out RaycastHit2D hit)
    {
        Ray ray = mainCamera.ScreenPointToRay(screenPosition);
        
        hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, stopRaycastLayers);
        
        if (hit.collider != null)
        {
            return true;
        }

        RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);
        
        if (hits.Length > 0)
        {
            hit = hits[0];
            return true;
        }

        hit = default;
        return false;
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
                switch (clickPhase)
                {
                    case InputActionPhase.Started:
                        clickable.OnClickDown(GetMouseWorldPosition());
                        if (clickable is IDraggable draggable)
                        {
                            draggingObjects.Add(draggable);
                        }
                        break;
                    case InputActionPhase.Canceled:
                        clickable.OnClickUp(GetMouseWorldPosition());
                        break;
                    case InputActionPhase.Performed:
                        clickable.OnClickPerformed(GetMouseWorldPosition());
                        break;
                }
            }
        }
        
        if (clickPhase == InputActionPhase.Canceled)
        {
            foreach (IDraggable draggable in draggingObjects)
            {
                draggable.OnEndDrag(GetMouseWorldPosition());
            }
            draggingObjects.Clear();
        }
    }

    public void AnyClick(InputActionPhase clickPhase)
    {
        Vector2 screenPosition = GetMouseWorldPosition();

        Root.Instance.AnyClickHandlerRegistry.OnAnyClick(screenPosition, clickPhase);
    }
    private void Update()
    {
        if (draggingObjects.Count == 0) return;
        
        foreach (IDraggable draggable in draggingObjects)
        {
            draggable.OnDrag(GetMouseWorldPosition());
        }
    }
}