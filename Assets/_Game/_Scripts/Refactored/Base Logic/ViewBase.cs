using UnityEngine;

public class ViewBase: MonoBehaviorInitable
{
    protected SpriteRenderer SpriteRenderer;
    protected AnimationsSettings AnimationsSettings;

    public override void Init()
    {
        base.Init();
        try
        {
            SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
            AnimationsSettings = Root.Instance.animationsSettings;
        }
        catch (MissingComponentException e)
        {
            Debug.LogError(e.Message);
        }
    }
}