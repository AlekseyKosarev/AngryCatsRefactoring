using UnityEngine;

public abstract class PhysicsBase: MonoBehaviour
{
    protected Rigidbody2D Rigidbody;
    protected Collider2D Collider;
    
    //Velocity
    private Vector2 _savedVelocity;
    private float _savedAngularVelocity;
    // private float _savedRotation;
    //Position
    private Vector3 savedPosition;
    private Quaternion savedRotation;
    public virtual void Init()
    {
        
    }
    private void Start()
    {
        try
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Collider = GetComponentInChildren<Collider2D>();
        }
        catch (MissingComponentException e)
        {
            Debug.LogError(e.Message);
        }
        Init();
    }
    public void ColliderSetActive(bool value)
    {
        Collider.enabled = value;
    }

    public void SetDefaultPhysics()
    {
        ColliderSetActive(true);
        OffRigidbodyNoSave();
    }

    public void OffRigidbodyNoSave()
    {
        ClearVelocity();
        ClearSavedVelocity();
        Rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }
    public void OffRigidbodyWithSave()
    {
        SaveVelocity();
        Rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }
    public void OnRigidBody()
    {
        LoadVelocity();
        Rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }
    private void SaveVelocity()
    {
        _savedVelocity = Rigidbody.linearVelocity;
        _savedAngularVelocity = Rigidbody.angularVelocity;
        // _savedRotation = Rigidbody.rotation;
        ClearVelocity();
    }
    private void LoadVelocity()
    {
        Rigidbody.linearVelocity = _savedVelocity;
        Rigidbody.angularVelocity = _savedAngularVelocity;
        // Rigidbody.rotation = _savedRotation;
        ClearSavedVelocity();
    }
    private void ClearVelocity()
    {
        Rigidbody.linearVelocity = Vector2.zero;
        Rigidbody.angularVelocity = 0f;
        // Rigidbody.rotation = 0f;
    }

    private void ClearSavedVelocity()
    {
        _savedVelocity = Vector2.zero;
        _savedAngularVelocity = 0f;
        // _savedRotation = 0f;
    }
    public void SaveTransform()
    {
        savedPosition = transform.position;
        savedRotation = transform.rotation;
    }
    public void LoadTransform()
    {
        transform.position = savedPosition;
        transform.rotation = savedRotation;
    }
}