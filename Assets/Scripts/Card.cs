using System;
using UnityEngine;

namespace Gameplay
{
    public class Card : MonoBehaviour
    {
        public int Value => _value;
        
        [SerializeField] private int _value;
        [SerializeField] private SpriteRenderer _greenCover;
        [SerializeField] private SpriteRenderer _redCover;
        [SerializeField] private SpriteRenderer _greyCover;
        [SerializeField] private Vector3 _targetPosition;
        [SerializeField] private bool _isRight;

        private Vector3 _startPos;
        private Camera _camera;
        private bool _drag;
        private float _minY;

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
                if (GameManager.Instance.PlayerTurn == false)
                {
                    PlayerHolder.Instance.PickedCard = _value;
                    GameManager.Instance.ShowHands();
                }
                else
                {
                    PlayerHolder.Instance.PickedCard = _value;
                    GameManager.Instance.DisableCardsWithoutColorize();
                    StartCoroutine(EnemyHolder.Instance.PickCard(true));
                }
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

        public void MarkRed()
        {
            _redCover.color = new Color(_redCover.color.r, _redCover.color.g, _redCover.color.b, 0.6f);
        }

        public void Disable(bool colorize)
        {
            if (colorize)
                _greyCover.color = new Color(_greyCover.color.r, _greyCover.color.g, _greyCover.color.b, 0.6f);
            GetComponent<Collider>().enabled = false;
        }

        public void Enable()
        {
            _greyCover.color = new Color(_greyCover.color.r, _greyCover.color.g, _greyCover.color.b, 0);
            GetComponent<Collider>().enabled = true;
        }

        public void ResetColor()
        {
            var color = _redCover.color;
            color = new Color(color.r, color.g, color.b, 0);
            _redCover.color = color;
            
            var color1 = _greenCover.color;
            color1 = new Color(color1.r, color1.g, color1.b, 0);
            _greenCover.color = color1;
        }
    }
}