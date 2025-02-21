using System;
using _Game._Scripts.Copy.Projectile;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Game._Scripts.Copy.Launcher
{
    [RequireComponent(typeof(LineRenderer))]
    public class Launcher: Singleton<Launcher>, IPointerClickHandler, IPointerUpHandler, IDragHandler
    {
        private Vector2 _shootDir;
        [SerializeField] private float velocity;
        [SerializeField] private float sencetivity = 1f;

        //public ProjectileBird projectileB;
        [NonSerialized]public BaseProjectile currentProjectile;
        //
        private Vector2 _startCursorPos;
        private Vector2 _endCursorPos;

        private LineRenderer _line;
        private Collider2D _col;

        private bool _isLaunched;

        private void Start()
        {
            _line = this.gameObject.GetComponent<LineRenderer>();
            _col = GetComponent<Collider2D>();
        }

        private void Launch()
        {
            if (_isLaunched) return;
        
            ReloadBegin();
            SetDir();
        
            currentProjectile.Launch(_shootDir, velocity);
        
            ClearTrajectory();
        }

        public void ReloadEnd()
        {
            _isLaunched = false;
            _col.enabled = true;
        }

        public void ReloadBegin()
        {
            _isLaunched = true;
            _col.enabled = false;
        }
    

        private void SetDir()
        {
            _shootDir = _endCursorPos - _startCursorPos;
            _shootDir = Vector2.ClampMagnitude(_shootDir,250) / 50*sencetivity;
            _shootDir = -_shootDir;
        
            var projectilePos = currentProjectile.Transform.position;
            var startDrawPos = new Vector2(projectilePos.x, projectilePos.y);
            var vel = _shootDir * velocity;
        
            DrawTrajectory(startDrawPos, vel, currentProjectile.Mass);
        }
    

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_isLaunched && !GameManager.Instance.inGame) return;
        
            //
        }
    
        public void OnPointerUp(PointerEventData eventData)
        {
            if (_isLaunched && !GameManager.Instance.inGame) return;
        
            Launch();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_isLaunched && !GameManager.Instance.inGame) return;
        
            _startCursorPos = eventData.pressPosition;
            _endCursorPos = eventData.position;
        
            SetDir();
        }
    
        private void DrawTrajectory(Vector2 startPos, Vector2 startVelocity, float mass = 1f)
        {
            var verts = 100;
        
            _line.positionCount = verts;

            var pos = startPos;
            var vel = startVelocity / mass;
            var grav = new Vector2(Physics.gravity.x, Physics.gravity.y);
            for(var i = 0; i < verts; i++)
            {
                _line.SetPosition(i, new Vector3(pos.x, pos.y, 0));
                vel = vel + grav * Time.fixedDeltaTime;
                pos = pos + vel * Time.fixedDeltaTime;
            }
        }

        private void ClearTrajectory()
        {
            _line.positionCount = 0;
        }
    
    }
}
