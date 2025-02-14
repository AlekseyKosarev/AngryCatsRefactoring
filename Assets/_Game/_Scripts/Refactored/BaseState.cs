using _Project.System.StateMachine.Interfaces;

public abstract class BaseState<T>: IState<T>
{
    public uint Index { get; set; }
    
    private bool _isFirstEnter = true;
    public abstract void Init(T context);
    public virtual void EnterState(T context)
    {
        if (_isFirstEnter)
        {
            _isFirstEnter = false;
            Init(context);
        }
    }

    public abstract void ExitState(T context);

    public abstract void UpdateState(T context);
}