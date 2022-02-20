using System;
using UnityEngine;

namespace Gameplay
{
    public class HandDrag : MonoBehaviour
    {
        [SerializeField] private float _minY;
        private Vector3 _startPos;
        private Camera _camera;
        private bool _drag;

        private void Awake() => _camera = Camera.main;

        public void StartDrag()
        {
            _drag = true;
            _startPos = transform.position;
        }

        public void EndDrag()
        {
            _drag = false;
            if (transform.position.y - _minY < 0.001f)
            {
                GameManager.Instance.StartCardsState();
            }
            transform.position = _startPos;
        }

        private void Update()
        {
            if (_drag)
            {
                var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                var clamp = Math.Clamp(mousePosition.y, _minY, _startPos.y);
                
                transform.position = new Vector3(transform.position.x, clamp, transform.position.z);
            }
        }
    }
}