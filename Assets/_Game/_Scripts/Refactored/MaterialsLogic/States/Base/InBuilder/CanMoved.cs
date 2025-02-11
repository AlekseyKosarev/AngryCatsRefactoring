// public class CanMoved: BaseState<MaterialContext>
// {
//     
//     //тут в апдейте происходит просто перемещение объекта по Vector2 
//     //также есть Enum:ModeMove - либо Drag, либо Move Step
//     //
//     public override void Init()
//     {
//     }
//
//     public override void ExitState(MaterialContext context)
//     {
//     }
//
//     // public override void UpdateState(MaterialContext context)
//     // {
//     //     switch (context.MoveData.MoveType)
//     //     {
//     //         case MoveType.Drag:
//     //             Drag(context);
//     //             break;
//     //         case MoveType.Step:
//     //             MoveStep(context);
//     //             break;
//     //     }
//     // }
//     // private void Drag(MaterialContext context)
//     // {
//     //     var moveVector = context.MoveData.Direction;
//     //     context.Transform.Translate(moveVector);
//     // }
//     // private void MoveStep(MaterialContext context)
//     // {
//     //     var moveVector = context.MoveData.Direction;
//     //     context.Transform.position += moveVector.normalized * context.MoveData.StepSize;
//     // }
// }