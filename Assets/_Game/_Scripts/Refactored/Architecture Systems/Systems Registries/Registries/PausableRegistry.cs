using System.Collections.Generic;
using UnityEngine;

public class PausableRegistry
{
    private List<IPausable> _pausableObjects = new();
    private bool _modeActive = false;
    public void Add(IPausable pausableObject) => _pausableObjects.Add(pausableObject);
    public void AddRange(List<IPausable> pausableObjects) => _pausableObjects.AddRange(pausableObjects);
    
    public void Remove(IPausable pausableObject) => _pausableObjects.Remove(pausableObject);
    public void Clear() => _pausableObjects.Clear();
    
    // public void EnterPauseMode() => _pausableObjects.ForEach(pausableObject => pausableObject.PauseMode_Enable());
    // public void ExitPauseMode() => _pausableObjects.ForEach(pausableObject => pausableObject.PauseMode_Disable());
    
    public void EnterPauseMode()
    {
        _modeActive = true;
        foreach (var pausableObject in _pausableObjects)
        {
            if (pausableObject != null)
            {
                pausableObject.PauseMode_Enable();
            }
            else
            {
                Debug.LogWarning("Found a null pausableObject in the registry.");
            }
        }
    }

    public void ExitPauseMode()
    {
        _modeActive = false;
        foreach (var pausableObject in _pausableObjects)
        {
            if (pausableObject != null)
            {
                pausableObject.PauseMode_Disable();
            }
            else
            {
                Debug.LogWarning("Found a null pausableObject in the registry.");
            }
        }
    }
    private void TogglePauseMode()
    {
        if(_modeActive)
            ExitPauseMode();
        else
            EnterPauseMode();
    }
}