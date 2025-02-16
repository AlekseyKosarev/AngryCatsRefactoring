using UnityEngine;

public class Material_Physics: MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _savedVelocity;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void PausePhysics()
    {
        _savedVelocity = _rigidbody.linearVelocity;
        _rigidbody.linearVelocity = Vector2.zero;
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }

    public void ResumePhysics()
    {
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody.linearVelocity = _savedVelocity;
    }
}