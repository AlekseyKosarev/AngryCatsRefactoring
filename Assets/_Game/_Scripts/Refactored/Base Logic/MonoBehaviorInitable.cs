using UnityEngine;

public abstract class MonoBehaviorInitable: MonoBehaviour
{
    private bool _isFirstEnter = true;

    public virtual void Init()
    {
        if(!_isFirstEnter) return;
    }
    protected void ResetInit() => _isFirstEnter = true;
    protected void InitComplete() => _isFirstEnter = false;
    public bool IsInitialized() => _isFirstEnter;
}