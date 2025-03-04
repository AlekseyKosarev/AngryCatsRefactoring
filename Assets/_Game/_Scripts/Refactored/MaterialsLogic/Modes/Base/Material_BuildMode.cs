using System;
using UnityEngine;

public class Material_BuildMode: BaseState<Material_Context>
{
    // private StateMachine<MaterialContext> _statesInBuildMode;
    
    public override void Init(Material_Context context)
    {
        Debug.Log("BUILDMode INIT");
    }

    public override void EnterState(Material_Context context)
    {
        Root.Instance.Material_BuildMode = true;
        // context.Rb.bodyType = RigidbodyType2D.Kinematic;
        context.Physics.OffRigidbodyNoSave();
        context.InputHandler.InputEnabled = true;
    }

    public override void ExitState(Material_Context context)
    {
        Root.Instance.Material_BuildMode = false;
        context.InputHandler.SetSelect(false);
        context.InputHandler.InputEnabled = false;
        
        context.Physics.SaveTransform();
    }

    public override void UpdateState(Material_Context context)
    {
        var inputData = context.InputData;
        
        // if(inputData.MoveType == MoveType.None) return;
        if (inputData.Selected)//нажат объект
        {
            Selected(context);
            UpdateRotation(context);
        }
        else
        {
            Deselected(context);
        }
        // if (_selected)
        // {
        //     Debug.Log("selected");
        // }
        UpdateMovement(context);
    }

    
    private void Selected(Material_Context context)
    {
        context.View.SetSelectedColor();
        
        // _statesInBuildMode.SetStateActive<CanMoved>(true, context);
    }
    private void Deselected(Material_Context context)
    {
        context.View.SetDefaultColor();
        // _statesInBuildMode.SetStateActive<CanMoved>(false, context);
    }
    
    private void UpdateMovement(Material_Context context)
    {
        if(context.InputData.Direction == Vector3.zero) return;
        switch (context.InputData.MoveType)
        {
            case MoveType.Drag:
                Drag(context);
                break;
            case MoveType.Step:
                MoveStep(context);
                break;
        }
    }
    private void Drag(Material_Context context)
    {
        context.Transform.position = Move(context.InputData.Direction + context.InputData.StartDirection);
        
    }
    private Vector3 Move(Vector2 worldPos)
    {
        // Применяем сетку к координатам
        float snappedX = SnapToGrid(worldPos.x);
        float snappedY = SnapToGrid(worldPos.y);
    
        return new Vector3(snappedX, snappedY, 0f);
    }

// Метод для привязки к сетке
    private float SnapToGrid(float value)
    {
        var gridSize = Root.Instance.levelBuildSettings.GridMoveSize; 
        if(gridSize <= 0) return value; // Защита от нулевого шага
        return Mathf.Round(value / gridSize) * gridSize;
    }
    private void MoveStep(Material_Context context)
    {
        Debug.Log("step move");
        var moveVector = context.InputData.Direction;
        context.Transform.position += moveVector.normalized * context.InputData.StepSize;
    }
    private void UpdateRotation(Material_Context context)
    {
        // Debug.Log(context.Transform.rotation);
        if (Mathf.Abs(context.InputData.RotateDelta) > 0) // Порог для обработки
        {
            context.Transform.rotation = Quaternion.Euler(0, 0, context.InputData.RotateAngle);
            // Debug.Log($"Вращение: угол = {context.InputData.RotateAngle}, дельта = {context.InputData.RotateDelta}");
        }
    }
}