using UnityEngine;

public class Material_Physics: MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    
    private Vector2 _savedVelocity;
    private float _savedAngularVelocity;
    private float _savedRotation;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Off_NoSaveVelocity()
    {
        SetNull();
        DeleteSave();
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }
    public void Off_SaveVelocity()
    {
        Save();
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }
    public void SetPlayMode()
    {
        Load();
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }
    private void Save()
    {
        _savedVelocity = _rigidbody.linearVelocity;
        _savedAngularVelocity = _rigidbody.angularVelocity;
        _savedRotation = _rigidbody.rotation;
        SetNull();
    }
    private void Load()
    {
        _rigidbody.linearVelocity = _savedVelocity;
        _rigidbody.angularVelocity = _savedAngularVelocity;
        _rigidbody.rotation = _savedRotation;
        DeleteSave();
    }
    private void SetNull()
    {
        _rigidbody.linearVelocity = Vector2.zero;
        _rigidbody.angularVelocity = 0f;
        _rigidbody.rotation = 0f;
    }

    private void DeleteSave()
    {
        _savedVelocity = Vector2.zero;
        _savedAngularVelocity = 0f;
        _savedRotation = 0f;
    }
}