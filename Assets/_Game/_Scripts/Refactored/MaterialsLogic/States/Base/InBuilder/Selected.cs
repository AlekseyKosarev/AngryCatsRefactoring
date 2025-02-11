public class Selected: BaseState<MaterialContext>
{
    public override void Init()
    {
        //тут будет
    }

    public override void EnterState(MaterialContext context)
    {
        //отрисовка того что объект выбран
        context.View.SetSelectedColor();
    }

    public override void ExitState(MaterialContext context)
    {
        //отрисовка того что объект не выбран
        context.View.SetDefaultColor();
    }

    public override void UpdateState(MaterialContext context)
    {
        
    }
}