using System;
using System.Collections.Generic;
using AnimationSchemas;
using UnityEngine;
using Utils;
using Zenject;

namespace Infrastructure
{
    public class PlayerHolder : MonoBehaviour
    {
        public int PebblesLeft { get; private set; } = 3;
        public int PebblesPicked { get; set; }
        public int CardValue { get; set; }

        [SerializeField] private List<SpriteRenderer> _fistPebbles;
        [SerializeField] private List<SpriteRenderer> _handPebbles;
        [SerializeField] private SpriteRenderer _noPebbleSign;
        [SerializeField] private AnimatorScheduler _animator;

        public void ShowFist()
        {
            SetupFist();
            _animator.ShowPlayerFist();
        }

        private void SetupFist()
        {
            _noPebbleSign.enabled = false;
            for (var i = 0; i < _fistPebbles.Count; i++)
            {
                _fistPebbles[i].enabled = false;
                _handPebbles[i].enabled = false;
            }

            if (PebblesPicked == 0)
            {
                _noPebbleSign.enabled = true;
                return;
            }
            
            for (int i = 0; i < PebblesPicked; i++)
            {
                _fistPebbles[i].enabled = true;
                _handPebbles[i].enabled = true;
            }
        }
    }
}