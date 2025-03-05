using System.Linq;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public ZoneType Type;

    private Bounds GetBounds()
    {
        Vector2 size = new Vector2(transform.lossyScale.x, transform.lossyScale.y);
        return new Bounds(transform.position, size);
    }

    public bool ContainsPoint(Vector2 point)
    {
        return GetBounds().Contains(point);
    }

    public bool ContainsCollider(Collider2D otherCollider)
    {
        return GetBounds().Intersects(otherCollider.bounds);
    }

    public bool ContainsRectTransform(RectTransform rectTransform)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        return corners.Any(corner => ContainsPoint(corner));
    }
}