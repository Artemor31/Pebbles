using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class EnemyHolder : MonoBehaviour
    {
        public static EnemyHolder Instance;
        
        public Action<int> ValuePicked;
        public int PebblesPicked => _pebblesPicked;
        public int PickedCard => _pickedCard;

        [SerializeField] private List<SpriteRenderer> _pebbleInHand;
        [SerializeField] private AnimatorScheduler _animator;
        [SerializeField] private GameTimer _timer;
        private int _pebblesLeft;
        private int _pickedCard;
        private int _pebblesPicked;       
        private GameManager _gameManager;

        [Inject]
        public void Constructor(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void Awake()
        {
            _pebblesLeft = 3;
            Instance = FindObjectOfType<EnemyHolder>();
        }
        
        private void HidePebbles()
        {
            var max = _pebblesLeft + 1;
            _pebblesPicked = Random.Range(0, max);
        }

        private void ChooseCard(bool firstTurn)
        {
            var player = PlayerHolder.Instance;
            
            if (firstTurn)
            {
                var maxInclusive = _pebblesPicked + player.PebblesLeft + 1;
                _pickedCard = Random.Range(_pebblesPicked, maxInclusive);
            }
            else
            {
                var stMax = player.PebblesLeft;

                var min = player.CardValue <= stMax
                           ? _pebblesPicked
                           : _pebblesPicked + (player.CardValue - stMax);

                var max = player.CardValue > 0
                           ? player.PebblesLeft + _pebblesPicked
                           : player.CardValue + _pebblesPicked;

                _pickedCard = Random.Range(min, max + 1);

                if (_pickedCard == player.CardValue)
                {
                    _pickedCard = _pickedCard == 6 
                                ? _pickedCard - 1 
                                : _pebblesPicked + 1;
                }
            }
        }

        private void SetupPebblesInHand()
        {
            foreach (var spriteRenderer in _pebbleInHand) 
                spriteRenderer.enabled = false;

            for (var i = 0; i < PebblesPicked; i++) 
                _pebbleInHand[i].enabled = true;
        }

        public IEnumerator ChoosingPebbles()
        {
            HidePebbles();
            SetupPebblesInHand();
            yield return new WaitForSeconds(Random.Range(3, 8));
            _animator.ShowEnemyFist();
            _gameManager.AiReady = true;
            _timer.StopAI();
        }
        
        public IEnumerator PickingCard()   
        {
            var seconds = Random.Range(3, 5);
            yield return new WaitForSeconds(seconds);
            ChooseCard(!_gameManager.PlayerTurn);
            ValuePicked?.Invoke(_pickedCard);
        }
    }
}