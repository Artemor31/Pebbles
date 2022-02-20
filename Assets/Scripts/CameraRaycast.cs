using UnityEngine;

namespace Gameplay
{
    public class CameraRaycast : MonoBehaviour
    {
        private Camera _camera;
        private Pebble _pebble;
        private HandDrag _hand;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var hits = CastRay(out var length);
                for (var i = 0; i < length; i++)
                {
                    CheckPebbleClick(hits[i]);
                    CheckHandClick(hits[i]);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                CheckHandUp();
                
                var hits = CastRay(out var length);
                for (var i = 0; i < length; i++)
                {
                    CheckPebbleUp(hits, i);
                }
            }
        }

        private void CheckHandUp()
        {
            if (_hand != null)
            {
                _hand.EndDrag();
                _hand = null;
            }
        }

        private void CheckPebbleUp(RaycastHit[] hits, int i)
        {
            if (_pebble != null && hits[i].transform.TryGetComponent(out HandHolder handHolder))
            {
                handHolder.PlacePebble(_pebble);
                _pebble = null;
            }
        }

        private void CheckHandClick(RaycastHit hit)
        {
            if (hit.transform.TryGetComponent(out HandDrag handDrag) == false) return;
            if (_pebble != null) return;
            
            _hand = handDrag;
            handDrag.StartDrag();
        }

        private void CheckPebbleClick(RaycastHit hit)
        {
            if (hit.transform.TryGetComponent(out Pebble pebble) == false) return;
            if (pebble.enabled == false) return;
            
            pebble.StartDrag();
            _pebble = pebble;
        }

        private RaycastHit[] CastRay(out int length)
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            var hits = new RaycastHit[3];
            length = Physics.RaycastNonAlloc(ray, hits, 10000);
            return hits;
        }
    }
}