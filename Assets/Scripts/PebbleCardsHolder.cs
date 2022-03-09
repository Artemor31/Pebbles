using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class PebbleCardsHolder : MonoBehaviour
    {
        [SerializeField] private List<PebbleCard> _cards;

        public void PreAnimate()
        {
            foreach (var pebbleCard in _cards) 
                pebbleCard.SetToAnimate();
        }

        public void PrePick()
        {
            foreach (var pebbleCard in _cards) 
                pebbleCard.SetToPick();
        }
    }
}