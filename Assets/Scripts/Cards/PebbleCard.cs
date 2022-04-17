using System;
using System.Reflection.Emit;
using Infrastructure;
using StateMachine;
using UnityEngine;
using Zenject;

namespace Cards
{
    public class PebbleCard : MonoBehaviour, ICard
    {
        public int Value => _value;
        public CardDecorator Decorator => _decorator;

        [SerializeField] private CardDecorator _decorator;
        [SerializeField] private Vector3 _targetPosition;
        [SerializeField] private bool _isRight;
        [SerializeField] private int _value;

        private Vector3 _startPos;
        private Camera _camera;
        private float _minY;
        private bool _drag;
        private PebbleState _pebbleState;

        [Inject]
        public void Constructor(PebbleState pebbleState) => 
            _pebbleState = pebbleState;

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
                _pebbleState.PlayerPickedPebbles(_value);
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
            if (_drag == false) return;
            
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