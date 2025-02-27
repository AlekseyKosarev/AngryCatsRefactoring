using System;
using System.Collections.Generic;
using _Game._Scripts.Copy.Projectile;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Game._Scripts.Copy.TIle
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile: MonoBehaviour, IDamageable, IDying
    {
        [SerializeField] private List<Sprite> parts; 
        

        private Tween _rotateTween;

        // private bool _isDrag;

        private BoxCollider2D _boxColl;
        private CircleCollider2D _cirColl;
        private Collider2D _currentCollider;
        private Rigidbody2D _rb;

        private SpriteRenderer _spriteRenderer;
        private Color _defColor;
        private bool _contacted = true;
        private bool _simulated = false;
        
        //DATA SO
        public TileDataSO dataSO; 
        //data for constructor
        public ItemType itemTypeData;
        private float _maxHpData;
        private float _massData;
        private float _gravityScaleData;
        //
        
        // IDamageable 
        private float _hp = 100;
        

        private void Start()
        {
            Init();
            OnDead += ((IDying) this).Die;
        }

        public void Init()
        {
            SetDataFromSO(dataSO);
            GetComponents();
            ApplyDataForComponents();
            ChangeDefColliderSettings();
            StartSimulation();
            //StopSimulation();
        }
        public void SetDataFromSO(TileDataSO data)     //раньше вызывалось при создании из TileConstructor
        {
            itemTypeData = data.type;
            _maxHpData = data.maxHp;
            _massData = data.mass;
            _gravityScaleData = data.gravityScale;
        }

        private void GetComponents()
        {
            _rb = GetComponent<Rigidbody2D>();
            
            if (TryGetComponent<BoxCollider2D>(out var box))
            {
                _boxColl = box;
                _currentCollider = box;
            }
            else if(TryGetComponent<CircleCollider2D>(out var cir))
            {
                _cirColl = cir;
                _currentCollider = cir;
            }
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        

        private void ApplyDataForComponents()
        {
            _defColor = _spriteRenderer.color;

            _rb.mass = _massData;
            MaxHp = _maxHpData;
            Hp = MaxHp;
        }

        private void ChangeDefColliderSettings()// TODO: переименовать - изменяет коллайдер в режиме редактирования
        {
            var offset = 0.15f;
            if (_boxColl != null)
            {
                var size = _boxColl.size;
                var kX = offset / transform.localScale.x;
                var kY = offset / transform.localScale.y;
                size = new Vector2(size.x - kX, size.y - kY); // нужно делать коллайдер чуть меньше, чтобы не было коллизий в редакторе
                _boxColl.size = size;
            }
            else if (_cirColl != null)
            {
                var radius = _cirColl.radius;
                var kX = offset / transform.localScale.x;

                radius -= kX;// нужно делать коллайдер чуть меньше, чтобы не было коллизий в редакторе
                _cirColl.radius = radius;
            }
            else
            {
                Debug.LogError("COLLIDER = null, tile");
            }
        }

        public void StartSimulation()
        {
            _currentCollider.isTrigger = false;
            _rb.gravityScale = _gravityScaleData;
            _rb.linearVelocity = Vector2.zero;
            
            _simulated = true;

            Revival();
        }
        public void StopSimulation()
        {
            _currentCollider.isTrigger = true;
            _rb.gravityScale = 0;
            _rb.linearVelocity = Vector2.zero;
            _rb.angularVelocity = 0;

            _simulated = false;
            
            Revival();
        }
        
        // public void OnPointerUp(PointerEventData eventData)
        // {
        //     if(_simulated) return;
        //
        //     CheckForDeleteTile();    
        //     if (_isDrag)
        //     {
        //         _isDrag = false;
        //         return;
        //     }
        //     
        //     Rotate();
        // }
        public void OnPointerClick(PointerEventData eventData)
        {
            if(_simulated) return;
            // TileMoveController.Instance.SetSelectedTile(this.gameObject);
            // _isDrag = false;
        }

        // public void OnDrag(PointerEventData eventData)
        // {
        //     if(_simulated) return;
        //
        //     CheckContacts();
        //     _isDrag = true;
        //     Move(eventData.position);
        // }

        // public void Move(Vector2 posDrag)
        // {
        //     var worldPos = Camera.main.ScreenToWorldPoint(posDrag);
        //     var dragPos = new Vector2(worldPos.x, worldPos.y);
        //
        //     var x = (float)Math.Round(dragPos.x, 1);
        //     var y = (float)Math.Round(dragPos.y, 1);
        //     
        //     var convertPos = new Vector2(x, y);
        //     
        //     var toMovePos = convertPos;
        //     
        //     transform.position = toMovePos;
        // }
        // public void Rotate()
        // {
        //     if(_rotateTween != null) return;
        //     
        //     var angle = TilesController.Instance.rotationAngle;
        //     var angleT = 15f;
        //     var timeRotation = TilesController.Instance.timeRotation;
        //     var localRot = (float)Math.Round(transform.localRotation.eulerAngles.z);
        //     localRot -= (localRot % angle);
        //     var testA = localRot % angleT;
        //     var endRot = new Vector3(0, 0, angle) + new Vector3(0,0,localRot);
        //     _rotateTween = transform.DOLocalRotate(endRot, timeRotation).OnComplete((() =>
        //     {
        //          _rotateTween.Kill();
        //          _rotateTween = null;
        //     }));
        // }

        public bool CheckContacts()
        {
            //_boxColl = GetComponent<BoxCollider2D>();
            var cont = new List<Collider2D>{};

            var countContacts = _currentCollider.GetContacts(cont);
            if (countContacts > 0)
            {
                Contact();
            }
            else
            {
                NoneContacts();
            }

            return _contacted;
        }

        private void Contact()
        {
            if(_contacted) return;
            _contacted = true;
            
            _spriteRenderer.color = Color.red; //TODO: перенести логику в контроллер
        }
        private void NoneContacts()
        {
            if(!_contacted) return;
            _contacted = false;
            
            _spriteRenderer.color = _defColor; //TODO: перенести логику в контроллер
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            CheckContacts();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            CheckContacts();
        }

        private void CheckForDeleteTile() // TODO: переименовать
        {
            //если этого тайла нет в зоне удаления - выходим
            if (AreasChecker.Instance.CheckContains(transform.position) == false) return;
            
            TilesController.Instance.RemoveOneTile(this);
        }

        public float MaxHp { get; set; }

        public float Hp
        {
            get => _hp;
            set
            {
                if (value <= 0)
                {
                    _hp = 0;
                    Alive = false;
                    OnDead?.Invoke();
                }
                else
                {
                    _hp = value;
                }
            }
        }

        public bool Alive { get; set; }
        public Action OnDead { get; set; }
        public void GetDamage(float dmg)
        {
            Hp -= dmg;
            UpdateVisualState();
        }

        private void UpdateVisualState()
        {
            var part = GetPartHp(parts.Count)-1;
            GetComponent<SpriteRenderer>().sprite = parts[part];
        }

        private int GetPartHp(int count)
        {
            var countParts = count;//количество частей(степеней поломки)
            var part = MaxHp / countParts;
            for (int i = 1; i <= countParts; i++)
            {
                if (Hp >= MaxHp - part * i)
                {
                    return i;
                }
            }
            return 0;
        }

        public Action DieCallback { get; set; }
        void IDying.Die()
        {
            Debug.Log("DIE Tile");
            gameObject.SetActive(false);
            DieCallback?.Invoke();
        }
        

        private void Revival()
        {
            if(MaxHp <= 0)
                Debug.LogError("Max HP tile = 0 !!!");
            
            Alive = true;
            Hp = MaxHp;
            UpdateVisualState();
            gameObject.SetActive(true);
        }
    }
}