using System;
using Infrostructure;
using UnityEngine;
using Zenject;

namespace Cards
{
    public class Card : MonoBehaviour, ICard
    {
        public int Value => _value;
        
        [SerializeField] private int _value;
        [SerializeField] private SpriteRenderer _cover;
        [SerializeField] private SpriteRenderer _greenCover;
        [SerializeField] private SpriteRenderer _redCover;
        [SerializeField] private Vector3 _targetPosition;
        [SerializeField] private bool _isRight;

        private Vector3 _startPos;
        private Camera _camera;
        private bool _drag;
        private float _minY;
        private PlayerHolder _playerHolder;

        [Inject]
        public void Constructor(PlayerHolder playerHolder)
        {
            _playerHolder = playerHolder;
        }
        
        private void Awake() => _camera = Camera.main;

        public void StartDrag()
        {
            _drag = true;
            _startPos = transform.position;
            _minY = _targetPosition.y;
            transform.localScale *= 1.3f;
        }

        public void EndDrag()
        {
            _drag = false;
            if (transform.position.y - _minY < 0.001f)
            {
                _playerHolder.PickValue(_value);
                transform.position = _startPos;
                transform.localScale /= 1.3f;
            }
            else
            {
                _greenCover.color = new Color(_greenCover.color.r, _greenCover.color.g, _greenCover.color.b, 0);
                transform.position = _startPos;
                transform.localScale /= 1.3f;
            }
        }

        private void Update()
        {
            if (_drag)
            {
                var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

                var y = Math.Max(mousePosition.y, _targetPosition.y);
                y = Math.Min(y, _startPos.y);

                var x = 100 / Math.Abs(_targetPosition.y - _startPos.y) * Math.Abs(transform.position.y - _startPos.y);
                var percentage = x / 100;

                x = _isRight
                    ? _startPos.x - percentage * Math.Abs(_targetPosition.x - _startPos.x)
                    : _startPos.x + percentage * Math.Abs(_targetPosition.x - _startPos.x);

                transform.position = new Vector3(x, y, transform.position.z);

                _greenCover.color = new Color(_greenCover.color.r, _greenCover.color.g, _greenCover.color.b, percentage);
            }
        }

        public Card SetRed()
        {
            _redCover.color = new Color(_redCover.color.r, _redCover.color.g, _redCover.color.b, 0.6f);
            return this;
        }

        public Card SetClear()
        {            
            var color = _redCover.color;
            color = new Color(color.r, color.g, color.b, 0);
            _redCover.color = color;
            
            var color1 = _greenCover.color;
            color1 = new Color(color1.r, color1.g, color1.b, 0);
            _greenCover.color = color1;
            
            SetOpacity(false);
            return this;
        }

        public Card SetOpacity(bool on)
        {
            _cover.color = new Color(1, 1, 1, on ? 0.5f : 1);
            return this;
        } 
        
        public Card SetClickable(bool on)
        {
            GetComponent<Collider>().enabled = on;
            return this;
        }

        public Card SetAnimator(bool on)
        {
            GetComponent<Animator>().enabled = on;
            return this;
        }
    }
}