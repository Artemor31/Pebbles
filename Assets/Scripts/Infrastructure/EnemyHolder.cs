using Utils;
using System;
using Zenject;
using UnityEngine;
using AnimationSchemas;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Infrastructure
{
    public class EnemyHolder : MonoBehaviour
    {
        public int PebblesLeft { get; set; } = 3;
        public int PebblesPicked { get; private set; }
        public int CardValue { get; private set; }

        [SerializeField] private List<SpriteRenderer> _pebbleInHand;
        [SerializeField] private AnimatorScheduler _animator;
        [SerializeField] private GameTimer _timer;
        
        private PlayerHolder _playerHolder;

        [Inject]
        public void Constructor(PlayerHolder playerHolder)
        {
            _playerHolder = playerHolder;
        }

        public void StartChoosePebbles(Action onComplete) => 
            StartCoroutine(ChoosingPebbles(onComplete));

        public IEnumerator StartChoosingCards(bool firstTurn)
        {
            yield return new WaitForSeconds(4);
            ChooseCard(firstTurn);
        }

        private void ChooseCard(bool firstTurn)
        {
            if (firstTurn)
            {
                var maxInclusive = PebblesPicked + _playerHolder.PebblesLeft + 1;
                CardValue = Random.Range(PebblesPicked, maxInclusive);
            }
            else
            {
                var stMax = _playerHolder.PebblesLeft;

                var min = _playerHolder.CardValue <= stMax
                    ? PebblesPicked
                    : PebblesPicked + (_playerHolder.CardValue - stMax);

                var max = _playerHolder.CardValue > 0
                    ? _playerHolder.PebblesLeft + PebblesPicked
                    : _playerHolder.CardValue + PebblesPicked;

                CardValue = Random.Range(min, max + 1);

                if (CardValue == _playerHolder.CardValue)
                {
                    CardValue = CardValue == 6
                        ? CardValue - 1
                        : PebblesPicked + 1;
                }
            }
        }

        private IEnumerator ChoosingPebbles(Action onComplete)
        {
            HidePebbles();
            SetupPebblesInHand();
            yield return new WaitForSeconds(Random.Range(3, 8));
            _animator.ShowEnemyFist();
            _timer.StopAI();
            onComplete.Invoke();
        }

        private void HidePebbles()
        {
            var max = PebblesLeft + 1;
            PebblesPicked = Random.Range(0, max);
        }

        private void SetupPebblesInHand()
        {
            foreach (var spriteRenderer in _pebbleInHand) 
                spriteRenderer.enabled = false;

            for (var i = 0; i < PebblesPicked; i++) 
                _pebbleInHand[i].enabled = true;
        }
    }
}