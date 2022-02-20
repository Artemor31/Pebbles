using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gameplay
{
    public class Pebble : MonoBehaviour
    {
        private Vector3 _startPos;
        private Camera _camera;
        private bool _onDrag;

        private void Awake() => _camera = Camera.main;

        public void StartDrag()
        {
            _startPos = transform.position;
            _onDrag = true;
        }

        public void EndDrag()
        {
            _onDrag = false;
            _startPos = transform.position;
        }

        public void BackToStartPosition()
        {
            transform.position = _startPos;
        }

        private void Update()
        {
            if (_onDrag)
            {
                var worldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector3(
                    worldPoint.x,
                    worldPoint.y,
                    transform.position.z);
            }
        }
    }
}