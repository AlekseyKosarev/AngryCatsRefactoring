using System.Collections.Generic;

public class BuildableRegistry
{
    private List<IBuildable> _buildableObjects = new();
    public bool _modeActive;
    public void Add(IBuildable buildableObjects) => _buildableObjects.Add(buildableObjects);
    public void AddRange(List<IBuildable> buildableObjects) => _buildableObjects.AddRange(buildableObjects);
    
    public void Remove(IBuildable buildableObjects) => _buildableObjects.Remove(buildableObjects);
    public void Clear() => _buildableObjects.Clear();
    
    public void EnterBuildMode()
    {
        _modeActive = true;
        _buildableObjects.ForEach(pausableObject => pausableObject.BuildMode_Enable());
    }
    public void ExitBuildMode()
    {
        _modeActive = false;
        _buildableObjects.ForEach(pausableObject => pausableObject.BuildMode_Disable());
    }
    
    private void ToggleBuildMode()
    {
        if(_modeActive)
            ExitBuildMode();
        else
            EnterBuildMode();
    }
}