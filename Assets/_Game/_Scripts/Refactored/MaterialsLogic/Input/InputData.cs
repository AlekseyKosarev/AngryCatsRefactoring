public struct InputData
{
    //INPUT
    public bool ToSelect;
    public MoveType MoveType;//
    public MoveData MoveData;
    
    public InputData(MoveData moveData, MoveType moveType = MoveType.None, bool toSelect = false)//default None
    {
        MoveData = moveData;
        MoveType = moveType;
        ToSelect = toSelect;
    }

    public InputData(bool toSelect = false)
    {
        MoveData = new MoveData();
        MoveType = MoveType.None;
        ToSelect = toSelect;
    }
}