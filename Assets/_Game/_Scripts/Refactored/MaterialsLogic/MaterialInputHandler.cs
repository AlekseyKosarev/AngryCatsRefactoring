using UnityEngine;

public class MaterialInputHandler: MonoBehaviour, IClickable
{
    private bool _selected = false;
    private bool _dragged = false;
    
    private BaseMaterial _material;
    private InputData _inputData;

    private void Awake()
    {
        _material = GetComponent<BaseMaterial>();
        _inputData = new InputData();
    }

    public void OnClickDown()
    {
        Debug.Log("down");
    }

    public void OnClickUp()
    {
        Debug.Log("up");
        if(!_dragged)
            _selected = !_selected;
        _dragged = false;
        
    }

    public void OnClickPerformed()
    {
        Debug.Log("performed");

        _dragged = true;
    }

    private void Update()
    {
        if (_dragged)
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