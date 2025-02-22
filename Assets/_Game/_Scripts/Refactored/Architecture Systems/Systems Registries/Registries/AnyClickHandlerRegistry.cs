using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnyClickHandlerRegistry
{
    private List<IAnyClickHanbler> _anyClickHanblers = new();
    
    public void Add(IAnyClickHanbler anyClickHanbler) => _anyClickHanblers.Add(anyClickHanbler);
    public void AddRange(List<IAnyClickHanbler> anyClickHanblers) => _anyClickHanblers.AddRange(anyClickHanblers);
    
    public void Remove(IAnyClickHanbler anyClickHanbler) => _anyClickHanblers.Remove(anyClickHanbler);
    public void Clear() => _anyClickHanblers.Clear();
    
    public void OnAnyClick(Vector2 worldPointerPosition, InputActionPhase clickPhase)
    {
        _anyClickHanblers.ForEach(anyClickHanbler => anyClickHanbler.AnyClick(worldPointerPosition, clickPhase));
    }
    // public void OnClickDown(Vector2 worldPointerPosition)
    // {
    //     _anyClickHanblers.ForEach(anyClickHanbler => anyClickHanbler.AnyClickDown(worldPointerPosition));
    // }
    // public void OnClickUp(Vector2 worldPointerPosition)
    // {
    //     _anyClickHanblers.ForEach(anyClickHanbler => anyClickHanbler.AnyClickUp(worldPointerPosition));
    // }
}