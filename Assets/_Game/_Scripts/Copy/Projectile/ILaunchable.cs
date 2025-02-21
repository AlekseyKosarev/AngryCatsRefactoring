using System;
using UnityEngine;

namespace _Game._Scripts.Copy.Projectile
{
    public interface ILaunchable
    { 
        public Transform Transform { get; set; }
        public float Mass { get; set; }

        public Action LaunchedCallback { get; set; }
        public void Launch(Vector2 dir, float velocity);
    }
}