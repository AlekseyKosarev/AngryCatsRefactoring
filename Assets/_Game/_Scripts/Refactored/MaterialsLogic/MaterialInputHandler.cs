using UnityEngine;

public class MaterialInputHandler: MonoBehaviour, IClickable
{
    public bool inputEnabled;
    
    private bool _selected = false;
    private bool _isDragged = false;
    
    private BaseMaterial _material;
    private InputData _inputData;

    private void Awake()
    {
        _material = GetComponent<BaseMaterial>();
        _inputData = new InputData();
    }

    public void OnClickDown()
    {
        if (!inputEnabled) return;
        Debug.Log("down");
    }

    public void OnClickUp()
    {
        if (!inputEnabled) return;
        Debug.Log("up");
        if(!_isDragged)
            _selected = !_selected;
        _isDragged = false;
        
    }

    public void OnClickPerformed()
    {
        if (!inputEnabled) return;
        Debug.Log("performed");

        _isDragged = true;
    }

    private void Update()
    {
        if (!inputEnabled) return;
        
        if (_isDragged)
        {
            var mousePosition = Root.Instance.inputLogic.GetMouseWorldPosition();
            var dir = new Vector3(mousePosition.x, mousePosition.y, 0);
            _inputData.Direction = dir;
            _inputData.MoveType = MoveType.Drag;
        }
        else
        {
            _inputData.Direction = Vector3.zero;
            _inputData.MoveType = MoveType.None;
        }
        _inputData.Selected = _selected;
        // Debug.Log("selected = " + _selected + " dragged = " + _dragged + " direction = " + _inputData.Direction);

        _material.SetInputData(_inputData);
    }
}