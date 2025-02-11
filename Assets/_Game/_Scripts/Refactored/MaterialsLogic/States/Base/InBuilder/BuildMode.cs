using UnityEngine;

public class BuildMode: BaseState<MaterialContext>
{
    // private StateMachine<MaterialContext> _statesInBuildMode;
    private bool _selected = false;
    
    public override void Init()
    {
        Debug.Log("BUILDMode INIT");
        // _statesInBuildMode = new StateMachineBuilder<MaterialContext>()
        //     .AddState(new CanMoved())
        //     .Build();
    }

    public override void EnterState(MaterialContext context)
    {
        Debug.Log("BuildMode enter");
        context.Rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public override void ExitState(MaterialContext context)
    {
        Debug.Log("BuildMode exit");
    }

    public override void UpdateState(MaterialContext context)
    {
        var inputData = context.InputData;
        if (inputData.ToSelect)//нажат объект
        {
            inputData.ToSelect = false;
            if(_selected)
                Deselected(context);
            else
                Selected(context);
        }

        if (_selected)
        {
            Debug.Log("selected");
            UpdateMovement(context);
        }
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
        if(context.InputData.MoveData.Direction == Vector3.zero) return;
        switch (context.InputData.MoveData.MoveType)
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
        var moveVector = context.InputData.MoveData.Direction;
        context.Transform.Translate(moveVector);
    }
    private void MoveStep(MaterialContext context)
    {
        var moveVector = context.InputData.MoveData.Direction;
        context.Transform.position += moveVector.normalized * context.InputData.MoveData.StepSize;
    }
}