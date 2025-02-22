using UnityEngine;
using UnityEngine.InputSystem;

public interface IAnyClickHanbler
{
    public void AnyClick(Vector2 worldPointerPosition, InputActionPhase clickPhase);
    // public void AnyClickDown(Vector2 worldPointerPosition);
    // public void AnyClickUp(Vector2 worldPointerPosition);
}