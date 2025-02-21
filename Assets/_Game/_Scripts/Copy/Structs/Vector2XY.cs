using UnityEngine;

namespace _Game._Scripts.Copy.Structs
{
    public struct Vector2XY
    {
        public float X;
        public float Y;
        public Vector2XY(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Vector2XY(Vector3 vec)
        {
            X = vec.x;
            Y = vec.y;
        }
    }
}