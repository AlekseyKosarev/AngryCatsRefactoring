using UnityEngine;

public class Material_InputHandler: MonoBehaviour, IDraggable
{
    private bool _selected = false;
    private bool _isDragged = false;
    
    private Material_Base _material;
    private InputData _inputData;
    
    public bool InputEnabled { get; set; }

    private void Awake()
    {
        _material = GetComponent<Material_Base>();
        _inputData = new InputData();
    }
    public void OnClickDown(Vector2 worldPointerPosition){}

    public void OnClickUp(Vector2 worldPointerPosition)
    {
        if (!InputEnabled) return;
        
        if(!_isDragged)
            _selected = !_selected;
        _inputData.Selected = _selected;
    }

    public void OnClickPerformed(Vector2 worldPointerPosition)
    {
        if (!InputEnabled) return;

        _isDragged = true;
    }

    public void OnDrag(Vector2 worldPointerPosition)
    {
        if (!InputEnabled) return;
        
        var dir = new Vector3(worldPointerPosition.x, worldPointerPosition.y, 0);
        _inputData.Direction = dir;
        _inputData.MoveType = MoveType.Drag;
        
        _material.SetInputData(_inputData);
    }

    public void OnEndDrag(Vector2 worldPointerPosition)
    {
        if (!InputEnabled) return;

        _isDragged = false;
        _inputData.Direction = Vector3.zero;
        _inputData.MoveType = MoveType.None;
        
        _material.SetInputData(_inputData);
    }
}