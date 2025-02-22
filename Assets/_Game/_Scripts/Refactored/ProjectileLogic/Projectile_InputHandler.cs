using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile_InputHandler : MonoBehaviour, IDraggable, IAnyClickHanbler
{
    public bool InputEnabled { get; set; }
    public void OnClickDown(Vector2 worldPointerPosition)
    {

    }

    public void OnClickUp(Vector2 worldPointerPosition)
    {

    }

    public void OnClickPerformed(Vector2 worldPointerPosition)
    {

    }

    public void OnDrag(Vector2 worldPointerPosition)
    {

    }

    public void OnEndDrag(Vector2 worldPointerPosition)
    {

    }

    public void AnyClick(Vector2 worldPointerPosition, InputActionPhase clickPhase)
    {
        if(!InputEnabled) return;
        
        Debug.Log("AnyClick - Projectile");
    }
}