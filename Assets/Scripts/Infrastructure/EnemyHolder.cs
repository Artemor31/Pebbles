using System;
using System.Collections;
using System.Collections.Generic;
using AnimationSchemas;
using StateMachine;
using UnityEngine;
using Utils;
using Zenject;
using Random = UnityEngine.Random;

namespace Infrastructure
{
    public class EnemyHolder : MonoBehaviour
    {
        public int PebblesPicked { get; private set; }
        public int PickedCard { get; private set; }
        public int PebblesLeft { get; set; } = 3;

        [SerializeField] private List<SpriteRenderer> _pebbleInHand;
        [SerializeField] private AnimatorScheduler _animator;
        [SerializeField] private GameTimer _timer;
        
        private PlayerHolder _playerHolder;
        private PebbleState _pebbleState;

        [Inject]
        public void Constructor(PlayerHolder playerHolder, PebbleState pebbleState)
        {
            _playerHolder = playerHolder;
            _pebbleState = pebbleState;
        }

        public void StartChoosePebbles()
        {
            StartCoroutine(ChoosingPebbles());
        }

        private IEnumerator ChoosingPebbles()
        {
            HidePebbles();
            SetupPebblesInHand();
            yield return new WaitForSeconds(Random.Range(3, 8));
            _animator.ShowEnemyFist();
            _timer.StopAI();
            _pebbleState.EnemyPickedPebbles();
        }

        private void HidePebbles()
        {
            var max = PebblesLeft + 1;
            PebblesPicked = Random.Range(0, max);
        }

        private void ChooseCard(bool firstTurn)
        {
            if (firstTurn)
            {
                var maxInclusive = PebblesPicked + _playerHolder.PebblesLeft + 1;
                PickedCard = Random.Range(PebblesPicked, maxInclusive);
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

                PickedCard = Random.Range(min, max + 1);

                if (PickedCard == _playerHolder.CardValue)
                {
                    PickedCard = PickedCard == 6 
                                ? PickedCard - 1 
                                : PebblesPicked + 1;
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
    }
}