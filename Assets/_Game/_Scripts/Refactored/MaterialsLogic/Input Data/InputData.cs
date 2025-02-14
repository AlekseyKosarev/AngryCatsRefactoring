using UnityEngine;

public struct InputData
{
    //INPUT
    public bool Selected;
    
    public MoveType MoveType;
    
    public Vector3 Direction;
    public float StepSize;
    
    public InputData(MoveType moveType, Vector3 direction, float stepSize = 0f, bool selected = false)//default None
    {
        MoveType = moveType;
        Direction = direction;
        StepSize = stepSize;
        
        Selected = selected;
    }

    public InputData(bool selected = false)
    {
        MoveType = MoveType.None;
        Direction = Vector3.zero;
        StepSize = 0f;
        Selected = selected;
    }
}