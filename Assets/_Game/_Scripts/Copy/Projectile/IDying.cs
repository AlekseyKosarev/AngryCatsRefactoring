using System;

namespace _Game._Scripts.Copy.Projectile
{
    public interface IDying
    {
        public Action DieCallback { get; set; }
        protected internal void Die();// maybe IEnumerator....
    }
}
