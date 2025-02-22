using UnityEngine;

public interface IClickable
{
    public bool InputEnabled{ get; set; }
    void OnClickDown(Vector2 worldPointerPosition);
    void OnClickUp(Vector2 worldPointerPosition);
    void OnClickPerformed(Vector2 worldPointerPosition);
}