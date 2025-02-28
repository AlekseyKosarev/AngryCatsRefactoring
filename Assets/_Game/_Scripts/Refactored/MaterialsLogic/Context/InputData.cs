using UnityEngine;

public struct InputData
{
    //INPUT
    public bool Selected;
    
    public MoveType MoveType;
    public Vector3 StartDirection;
    public Vector3 Direction;
    public float StepSize;
    
    public float RotateAngle;
    public float RotateDelta;
    public InputData(MoveType moveType, Vector3 direction, Vector3 startDirection, float rotateAngle, float rotateDelta, bool selected = false, float stepSize = 0f)//default None
    {
        MoveType = moveType;
        StartDirection = startDirection;
        Direction = direction;
        StepSize = stepSize;
        
        Selected = selected;
        RotateAngle = rotateAngle;
        RotateDelta = rotateDelta;
    }

    public InputData(bool selected = false)
    {
        MoveType = MoveType.None;
        StartDirection = Vector3.zero;
        Direction = Vector3.zero;
        StepSize = 0f;
        Selected = selected;
        RotateAngle = 0f;
        RotateDelta = 0f;
    }
}