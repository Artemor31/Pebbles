using Cards;
using UnityEngine;

namespace Infrastructure
{
    public class CameraRaycast : MonoBehaviour
    {
        private Camera _camera;
        private ICard _card;

        private void Awake() => _camera = GetComponent<Camera>();

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var hits = CastRay(out var length);
                
                CheckCardClick(hits, length);
                CheckPebbleCardClick(hits, length);
            }

            CheckCardsClick();
        }

        private void CheckCardsClick()
        {
            if (Input.GetMouseButtonUp(0))
            {
                CheckCard(_card);
            }

            void CheckCard(ICard card)
            {
                if (card == null) return;
                card.EndDrag();
                card = null;
            }
        }

        private void CheckCardClick(RaycastHit[] hits, int length)
        {
            ValueCard topValueCard = null;
            var z = float.MaxValue;
            for (var i = length - 1; i >= 0; i--)
            {
                if (hits[i].transform.TryGetComponent(out ValueCard card))
                {
                    var positionZ = card.transform.position.z;
                    
                    if (positionZ < z)
                    {
                        z = positionZ;
                        topValueCard = card;
                    }
                }
            }

            if (topValueCard != null)
            {
                _card = topValueCard;
                _card.StartDrag();
            }
        }
        private void CheckPebbleCardClick(RaycastHit[] hits, int length)
        {
            PebbleCard topCard = null;
            var z = float.MaxValue;
            for (var i = length - 1; i >= 0; i--)
            {
                if (hits[i].transform.TryGetComponent(out PebbleCard card))
                {
                    var positionZ = card.transform.position.z;
                    
                    if (positionZ < z)
                    {
                        z = positionZ;
                        topCard = card;
                    }
                }
            }

            if (topCard != null)
            {
                _card = topCard;
                _card.StartDrag();
            }
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