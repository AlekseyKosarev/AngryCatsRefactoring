using UnityEngine;

public abstract class PhysicsBase: MonoBehaviour
{
    protected Rigidbody2D Rigidbody;
    
    private Vector2 _savedVelocity;
    private float _savedAngularVelocity;
    private float _savedRotation;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    public void OffClear()
    {
        SetNull();
        DeleteSave();
        Rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }
    public void OffWithSave()
    {
        Save();
        Rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }
    public void On()
    {
        Load();
        Rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }
    private void Save()
    {
        _savedVelocity = Rigidbody.linearVelocity;
        _savedAngularVelocity = Rigidbody.angularVelocity;
        _savedRotation = Rigidbody.rotation;
        SetNull();
    }
    private void Load()
    {
        Rigidbody.linearVelocity = _savedVelocity;
        Rigidbody.angularVelocity = _savedAngularVelocity;
        Rigidbody.rotation = _savedRotation;
        DeleteSave();
    }
    private void SetNull()
    {
        Rigidbody.linearVelocity = Vector2.zero;
        Rigidbody.angularVelocity = 0f;
        Rigidbody.rotation = 0f;
    }

    private void DeleteSave()
    {
        _savedVelocity = Vector2.zero;
        _savedAngularVelocity = 0f;
        _savedRotation = 0f;
    }
}