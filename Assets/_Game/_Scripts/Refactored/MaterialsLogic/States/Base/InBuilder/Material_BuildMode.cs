using System;
using UnityEngine;

public class Material_BuildMode: BaseState<MaterialContext>
{
    // private StateMachine<MaterialContext> _statesInBuildMode;
    private bool _selected = false;
    
    public override void Init(MaterialContext context)
    {
        Debug.Log("BUILDMode INIT");
        // _statesInBuildMode = new StateMachineBuilder<MaterialContext>()
        //     .AddState(new CanMoved())
        //     .Build();
    }

    public override void EnterState(MaterialContext context)
    {
        Root.Instance.Material_BuildMode = true;
        context.Rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public override void ExitState(MaterialContext context)
    {
        Root.Instance.Material_BuildMode = false;
    }

    public override void UpdateState(MaterialContext context)
    {
        var inputData = context.InputData;
        // if(inputData.MoveType == MoveType.None) return;
        if (inputData.Selected)//нажат объект
        {
            Selected(context);
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

    
    private void Selected(MaterialContext context)
    {
        _selected = true;
        context.View.SetSelectedColor();
        
        // _statesInBuildMode.SetStateActive<CanMoved>(true, context);
    }
    private void Deselected(MaterialContext context)
    {
        _selected = false;
        context.View.SetDefaultColor();
        // _statesInBuildMode.SetStateActive<CanMoved>(false, context);
    }
    
    private void UpdateMovement(MaterialContext context)
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
    private void Drag(MaterialContext context)
    {
        // Debug.Log("drag move");
        context.Transform.position = Move(context.InputData.Direction);
    }
    public Vector3 Move(Vector2 worldPos)
    {
        var dragPos = new Vector2(worldPos.x, worldPos.y);
    
        var x = (float)Math.Round(dragPos.x, 1);
        var y = (float)Math.Round(dragPos.y, 1);
        
        var convertPos = new Vector2(x, y);
        
        var toMovePos = convertPos;
        
        return toMovePos;
    }
    private void MoveStep(MaterialContext context)
    {
        Debug.Log("step move");
        var moveVector = context.InputData.Direction;
        context.Transform.position += moveVector.normalized * context.InputData.StepSize;
    }
}