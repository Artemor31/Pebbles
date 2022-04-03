using System;
using Infrastructure;
using UnityEngine;
using Zenject;

namespace Cards
{
    public class ValueCard : MonoBehaviour, ICard
    {
        public int Value => _value;
        public CardDecorator Decorator => _decorator;

        [SerializeField] private int _value;
        [SerializeField] private Vector3 _targetPosition;
        [SerializeField] private bool _isRight;
        [SerializeField] private CardDecorator _decorator;

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
                _decorator.SetGreen(0);
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

                _decorator.SetGreen(percentage);
            }
        }
    }
}