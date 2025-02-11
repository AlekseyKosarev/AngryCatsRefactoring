using UnityEngine;

public class MoveData
{
    public MoveType MoveType;
    public Vector3 Direction;
    public float StepSize;
    
    public MoveData(MoveType moveType, Vector3 direction, float stepSize = 0f)
    {
        MoveType = moveType;
        Direction = direction;
        StepSize = stepSize;
    }
    public MoveData()
    {
        MoveType = MoveType.None;
        Direction = Vector3.zero;
    }
}