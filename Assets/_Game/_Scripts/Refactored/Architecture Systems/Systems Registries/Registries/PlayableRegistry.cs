using System.Collections.Generic;

public class PlayableRegistry
{
    private List<IPlayable> _pausableObjects = new();
    private bool _modeActive;
    public void Add(IPlayable pausableObject) => _pausableObjects.Add(pausableObject);
    public void AddRange(List<IPlayable> pausableObjects) => _pausableObjects.AddRange(pausableObjects);
    
    public void Remove(IPlayable pausableObject) => _pausableObjects.Remove(pausableObject);
    public void Clear() => _pausableObjects.Clear();
    
    public void EnterPlayMode()
    {
        _modeActive = true;
        _pausableObjects.ForEach(pausableObject => pausableObject.PlayMode_Enable());
    }
    public void ExitPlayMode() 
    {
        _modeActive = false;
        _pausableObjects.ForEach(pausableObject => pausableObject.PlayMode_Disable());
    }
    
    private void TogglePlayMode()
    {
        if(_modeActive)
            ExitPlayMode();
        else
            EnterPlayMode();
    }
}