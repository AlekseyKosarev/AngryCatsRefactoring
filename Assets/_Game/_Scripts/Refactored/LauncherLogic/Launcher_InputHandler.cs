using UnityEngine;

public class Launcher_InputHandler: MonoBehaviour, IDraggable
{
    private bool _inputEnabled = true;
    private bool _isDragging;
    
    private Vector2 _startPosition;
    private Vector2 _endPosition;

    private Launcher_Base _launcherBase;

    public bool IsDragging => _isDragging;
    public Vector2 StartPosition => _startPosition;
    public Vector2 EndPosition => _endPosition;

    public void Input_Enable()
    {
        _inputEnabled = true;
    }
    public void Input_Disable()
    {
        _inputEnabled = false;
    }

    public void OnClickDown(Vector2 worldPointerPosition)
    {
        if (!_inputEnabled) return;
        Debug.Log("LAUNCHER BeginDrag");
        _startPosition = worldPointerPosition;
        _isDragging = true;
    }

    public void OnClickUp(Vector2 worldPointerPosition){}

    public void OnClickPerformed(Vector2 worldPointerPosition){}
    

    public void OnDrag(Vector2 worldPointerPosition)
    {
        if (!_inputEnabled) return;
        Debug.Log("LAUNCHER OnDrag");
        _endPosition = worldPointerPosition;
    }

    public void OnEndDrag(Vector2 worldPointerPosition)
    {
        if (!_inputEnabled) return;
        Debug.Log("LAUNCHER EndDrag");
        _endPosition = worldPointerPosition;
        _isDragging = false;
    }
}