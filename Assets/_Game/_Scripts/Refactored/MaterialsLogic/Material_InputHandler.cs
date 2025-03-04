using UnityEngine;
using UnityEngine.InputSystem;

public class Material_InputHandler: MonoBehaviour, IDraggable, IAnyClickHanbler, ISelectable
{
    private bool _selected = false;
    private bool _isDragged = false;
    
    private Material_Base _material;
    private InputData _inputData;

    private bool _clickedDown;
    public bool InputEnabled { get; set; }

    private void Awake()
    {
        _material = GetComponent<Material_Base>();
        _inputData = new InputData();
    }

    public void OnClickDown(Vector2 worldPointerPosition)
    {
        _clickedDown = true;
        _inputData.StartDirection = new Vector2(_material.transform.position.x, _material.transform.position.y) - worldPointerPosition;
    }

    public void OnClickUp(Vector2 worldPointerPosition)
    {
        if (!InputEnabled) return;
        if (!_clickedDown) return;
        if(!_isDragged)
            SetSelect(!_selected);
        
        _clickedDown = false;
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
    }

    public void OnEndDrag(Vector2 worldPointerPosition)
    {
        if (!InputEnabled) return;

        _isDragged = false;
        _inputData.StartDirection = Vector2.zero;
        _inputData.Direction = Vector3.zero;
        _inputData.MoveType = MoveType.None;
    }
    
    private bool _isRotating;
    private float _previousAngle;
    private float _accumulatedAngle;
    public void AnyClick(Vector2 worldPointerPosition, InputActionPhase clickPhase)
    {
        if (!InputEnabled) return;

        if (clickPhase == InputActionPhase.Started)
        {
            Vector2 direction = worldPointerPosition - (Vector2)transform.position;
            _previousAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
            // Приводим накопленный угол в диапазон 0-360
            _accumulatedAngle = _material.transform.localRotation.eulerAngles.z;//todo something
            if(_accumulatedAngle < 0) _accumulatedAngle += 360;
        
            _isRotating = true;
            _inputData.RotateDelta = 0f;
        }

        if (clickPhase == InputActionPhase.Canceled)
        {
            // Применяем финальное округление при отпускании
            _accumulatedAngle = SnapAngle(_accumulatedAngle);
            _isRotating = false;
        }
    }

    private void OnRotate(Vector2 worldPointerPosition)
    {
        Vector2 direction = worldPointerPosition - (Vector2)transform.position;
        float currentAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float angleDelta = Mathf.DeltaAngle(_previousAngle, currentAngle);

        _accumulatedAngle += angleDelta;
    
        // Применяем округление во время вращения
        float snappedAngle = SnapAngle(_accumulatedAngle);
    
        _inputData.RotateAngle = snappedAngle;
        _inputData.RotateDelta = angleDelta / 360f;
        _previousAngle = currentAngle;
    }

// Метод для округления до ближайшего шага сетки
    private float SnapAngle(float angle)
    {
        var snap = Root.Instance.levelBuildSettings.SnapAngle;
        return Mathf.Round(angle / snap) * snap;
    }

    private void Update()
    {
        if (_isRotating)
        {
            OnRotate(Root.Instance.inputLogic.GetMouseWorldPosition());
        }
        _material.SetInputData(_inputData);
    }

    public void Select()
    {
        _selected = true;
        _inputData.Selected = _selected;
    }

    public void Deselect()
    {
        _selected = false;
        _inputData.Selected = _selected;
    }

    public void SetSelect(bool value)
    {
        if (value == _selected) return;
        if (_selected)
        {
            Root.Instance.itemSelecter.ClearSelectedItems();
            Deselect();
        }
        else
        {
            Root.Instance.itemSelecter.SelectOneItem(gameObject.GetComponent<ISelectable>());
            Select();
        }
    }
}