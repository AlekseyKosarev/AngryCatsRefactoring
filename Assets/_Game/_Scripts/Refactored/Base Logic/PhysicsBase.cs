using System.Collections.Generic;
using UnityEngine;

public abstract class PhysicsBase: MonoBehaviour
{
    protected Rigidbody2D Rigidbody;
    protected Collider2D Collider;
    
    //Velocity
    private Vector2 _savedVelocity;
    private float _savedAngularVelocity;
    //Position
    private Vector3 savedPosition;
    private Quaternion savedRotation;
    public virtual void Init()
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
    }
    private void Start()
    {
        
        Init();
    }
    public void ColliderSetActive(bool value)
    {
        Collider.enabled = value;
    }

    public void ColliderSetTrigger(bool value)
    {
        Collider.isTrigger = value;
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
        ClearVelocity();
    }
    private void LoadVelocity()
    {
        Rigidbody.linearVelocity = _savedVelocity;
        Rigidbody.angularVelocity = _savedAngularVelocity;
        ClearSavedVelocity();
    }
    private void ClearVelocity()
    {
        Rigidbody.linearVelocity = Vector2.zero;
        Rigidbody.angularVelocity = 0f;
    }

    private void ClearSavedVelocity()
    {
        _savedVelocity = Vector2.zero;
        _savedAngularVelocity = 0f;
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
    public void SetRotation(float angle)
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    
    
    // public List<Collider2D> GetNearbyColliders()
    // {
    //     List<Collider2D> nearbyColliders = new List<Collider2D>();
    //
    //     ContactFilter2D filter = new ContactFilter2D(); // Можно настроить фильтр, если нужно
    //     filter.NoFilter(); // Отключаем фильтр, чтобы получить все коллайдеры
    //
    //     int colliderCount = Collider.Overlap(filter, nearbyColliders);
    //
    //     return nearbyColliders;
    // }
    public float GetImmersionDepth(Collider2D otherCollider)
    {
        ColliderDistance2D distance = Collider.Distance(otherCollider);

        if (distance.isOverlapped)
        {
            return Mathf.Abs(distance.distance);
        }

        return 0f;
    }
    public bool CheckContactsWithDepth(float requiredDepth)
    {
        List<Collider2D> contacts = new List<Collider2D>();
        int contactCount = Collider.GetContacts(contacts);

        if (contactCount == 0)
        {
            return false;
        }

        foreach (Collider2D contactCollider in contacts)
        {
            if (contactCollider.gameObject.layer == LayerMask.NameToLayer("UI"))//TODO возможно переделать.......
                continue;
            float immersionDepth = GetImmersionDepth(contactCollider);

            if (immersionDepth >= requiredDepth)
            {
                return true;
            }
        }

        return false;
    }
}