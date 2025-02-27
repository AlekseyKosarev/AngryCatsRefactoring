using System;
using System.Collections;
using UnityEngine;

namespace _Game._Scripts.Copy.Projectile
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class BaseProjectile: MonoBehaviour, ILaunchable, ITemporaryDying
    {
        public ProjectilesTypes type;
        public float mass = 1f;
        public float timeLife = 1f;
        private Rigidbody2D _rb;
        private CircleCollider2D _col;
        private Coroutine _counter;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.mass = mass;
            // _rb.isKinematic = true;
        
            _col = GetComponent<CircleCollider2D>();
            _col.enabled = false;
            Constructor();
        }
        private void Constructor() //ha ha ha ...
        {
            Transform = transform;
            Mass = mass;
            TimeLife = timeLife;

            TimeEnded += ((IDying) this).Die;
        }

        public Transform Transform { get; set; }
        public float Mass { get; set; }
        public Action LaunchedCallback { get; set; }

        public void Launch(Vector2 dir, float velocity)
        {
            // _rb.isKinematic = false;
            _col.enabled = true;
        
            _rb.AddForce(dir * velocity, ForceMode2D.Impulse);
            LaunchedCallback?.Invoke();

        
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            ((ITemporaryDying) this).StartTimer();// to die
            if (collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
            {
                var dmg = mass * _rb.linearVelocity.magnitude;
                dmg = (float)Math.Round(dmg, 2);
            
                damageable.GetDamage(dmg);
                Debug.Log($"{collision.gameObject.name}, hp = {damageable.Hp}, take dmg = {dmg}");
            }
        }

        public Action DieCallback { get; set; }
        void IDying.Die()
        {
            Debug.Log("Die...F");
            Destroy(gameObject);
            DieCallback?.Invoke();
        }

        public float TimeLife { get; set; }
        public Action TimeEnded { get; set; }

        Coroutine ITemporaryDying.Counter { get; set; }

        IEnumerator ITemporaryDying.CountTimeLife()
        {
            yield return new WaitForSeconds(TimeLife);
            TimeEnded?.Invoke();
            ((ITemporaryDying) this).Counter = null;
        }

        void ITemporaryDying.StartTimer()
        {
            if(((ITemporaryDying) this).Counter != null) return;
        
            if(TimeLife <= 0) Debug.LogError("Life time = 0 !!!");
            else
            {
                ((ITemporaryDying) this).Counter = StartCoroutine(((ITemporaryDying) this).CountTimeLife());
            }
        }
    }
}