using System;
using System.Collections.Generic;
using AnimationSchemas;
using UnityEngine;
using Zenject;

namespace Infrostructure
{
    public class PlayerHolder : MonoBehaviour
    {
        public Action<int> PickedValue;

        public int PebblesLeft { get; private set; }
        public int PebblesPicked { get; set; }
        public int CardValue { get; set; }

        [SerializeField] private List<SpriteRenderer> _fistPebbles;
        [SerializeField] private List<SpriteRenderer> _handPebbles;
        [SerializeField] private SpriteRenderer _noPebbleSign;
        [SerializeField] private AnimatorScheduler _animator;

        private GameManager _gameManager;

        [Inject]
        public void Constructor(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        
        private void Start()
        {
            PebblesLeft = 3;
        }

        public void ShowFist()
        {
            SetupFist();
            _animator.ShowPlayerFist();
            _gameManager.PlayerReady = true;
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

        public void PickValue(int value)
        {
            CardValue = value;
            PickedValue?.Invoke(value);
        }
    }
}