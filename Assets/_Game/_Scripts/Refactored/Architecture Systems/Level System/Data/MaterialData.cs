using System;
using UnityEngine;

[Serializable]
public struct MaterialData
{
    public ItemData itemData;
    public TestVector2 position;
    public float rotation;
}
[Serializable]
public struct TestVector2
{
    public float x;
    public float y;

    public TestVector2 (Vector2 vector)
    {
        x = vector.x;
        y = vector.y;
    }
    public TestVector2 (Vector3 vector)
    {
        x = vector.x;
        y = vector.y;
    }
}