using System;
using UnityEngine;

public class Launcher_InputHandler: MonoBehaviour, IDraggable
{
    private Launcher_Base _launcherBase;

    public bool InputEnabled{ get; set; }
    public event Action<Vector2> OnLaunchStart; 
    private bool _isDragging;
    
    private Vector2 _startPosition;
    private Vector2 _endPosition;

    public float maxDistance;
    private Vector2 _direction;//0-1f
    
    public bool IsDragging => _isDragging;

    private void Start()
    {
        _launcherBase = GetComponent<Launcher_Base>();
    }

    public void OnClickDown(Vector2 worldPointerPosition)
    {
        if (!InputEnabled) return;
        // Debug.Log("LAUNCHER BeginDrag");
        _startPosition = _launcherBase.pointOfLaunch.position;
        _isDragging = true;
    }

    public void OnClickUp(Vector2 worldPointerPosition){}

    public void OnClickPerformed(Vector2 worldPointerPosition){}
    

    public void OnDrag(Vector2 worldPointerPosition)
    {
        if (!InputEnabled) return;
        // Debug.Log("LAUNCHER OnDrag");
        _endPosition = worldPointerPosition;
        
        CalculateDirection();
    }

    public void OnEndDrag(Vector2 worldPointerPosition)
    {
        if (!InputEnabled) return;
        // Debug.Log("LAUNCHER EndDrag");
        _endPosition = worldPointerPosition;
        _isDragging = false;

        CalculateDirection();
        OnLaunchStart?.Invoke(-_direction);
    }

    private void CalculateDirection()
    {
        _direction = Vector2.ClampMagnitude(Vector2.ClampMagnitude(_endPosition - _startPosition, maxDistance), 1f);
    }
    public Vector2 GetDirection()
    {
        return _direction;
    }

    public Vector2 CalculateEndPoint()
    {
        var endPoint = _startPosition + _direction * maxDistance/2f;
        // Debug.Log("LAUNCHER endPoint = " + endPoint + " direction = " + _direction);
        return endPoint;
    }

    public Vector2 GetStartPoint()
    {
        return _startPosition;
    }
}