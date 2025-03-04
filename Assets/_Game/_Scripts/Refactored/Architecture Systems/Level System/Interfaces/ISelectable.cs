using UnityEngine;

public interface ISelectable
{
    public GameObject gameObject { get; }
    public void Select();
    public void Deselect();
    public void SetSelect(bool value);
}