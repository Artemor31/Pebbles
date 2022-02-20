using System;
using UnityEngine;

namespace Gameplay
{
    public class HandHolder : MonoBehaviour
    {
        [SerializeField] private PebblesPositions[] _positions;

        public void PlacePebble(Pebble pebble)          
        {
            foreach (var pebblesPositions in _positions)
            {
                if (pebblesPositions.Empty)
                {
                    pebble.transform.position = pebblesPositions.Transform.position;
                    pebblesPositions.Empty = false;
                    pebble.EndDrag();
                    pebble.transform.SetParent(transform);
                    pebble.enabled = false;
                    return;
                }
            }

            throw new UnityException("Not enough positions");
        }


        [Serializable]
        private class PebblesPositions
        {
            public bool Empty;
            public Transform Transform;
        }
    }
}