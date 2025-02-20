
using UnityEngine;

public interface IDraggable: IClickable
{
    void OnDrag(Vector2 worldPointerPosition);
    void OnEndDrag(Vector2 worldPointerPosition);
}