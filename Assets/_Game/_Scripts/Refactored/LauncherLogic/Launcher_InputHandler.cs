using UnityEngine;

public class Launcher_InputHandler: MonoBehaviour, IClickable
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

    public void OnClickDown()
    {
        if (!_inputEnabled) return;
        Debug.Log("LAUNCHER DOWN");
        _isDragging = true;
        _startPosition = Root.Instance.inputLogic.GetMouseWorldPosition();
    }

    public void OnClickUp()
    {
        if (!_inputEnabled) return;
        Debug.Log("LAUNCHER UP");
        _isDragging = false;
        _endPosition = Root.Instance.inputLogic.GetMouseWorldPosition();
    }

    public void OnClickPerformed()
    {
        if (!_inputEnabled) return;
        _endPosition = Root.Instance.inputLogic.GetMouseWorldPosition();
    }

    public void Update()
    {
        if (!_inputEnabled) return;
        if (!_isDragging) return;
        _endPosition = Root.Instance.inputLogic.GetMouseWorldPosition();
    }
}