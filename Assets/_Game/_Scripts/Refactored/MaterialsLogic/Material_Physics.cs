using UnityEngine;

public class Material_Physics: MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _savedVelocity;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Off_NoSaveVelocity()
    {
        ClearVelocity();
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }
    public void Off_SaveVelocity()
    {
        SaveVelocity();
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }
    public void SetPlayMode()
    {
        LoadVelocity();
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }
    private void SaveVelocity()
    {
        _savedVelocity = _rigidbody.linearVelocity;
        ClearVelocity();
    }
    private void LoadVelocity()
    {
        _rigidbody.linearVelocity = _savedVelocity;
    }
    private void ClearVelocity()
    {
        _rigidbody.linearVelocity = Vector2.zero;
    }
    
}