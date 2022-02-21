using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        [SerializeField] private AnimatorScheduler _scheduler;
        [SerializeField] private HandHolder _handHolder;
        [SerializeField] private List<Card> _cards;

        private int _playerPickValue;
        private bool _playerTurn;
        private IEnumerator _waitForFist;

        private void Start()
        {
            Instance = FindObjectOfType<GameManager>();
            
          //  if (Random.Range(0, 2) == 0) 
                _playerTurn = false;
            
            _scheduler.StartChain();
            StartPebbleChooseState();
        }

        public void StartPebbleChooseState()
        {
            _scheduler.StartChain();
            EnemyStartPebblesRoutine();
        }

        private void EnemyStartPebblesRoutine()
        {
            // Enemy calculate pebbles pick and show fist.
            EnemyHolder.Instance.HidePebbles();
            EnemyHolder.Instance.SetupPebblesInHand();
            _waitForFist = EnemyHolder.Instance.ShowFist();
            StartCoroutine(_waitForFist);
        }

        public void StartCardsState()
        {
            if (EnemyHolder.Instance.Waiting)
            {
                StopCoroutine(_waitForFist);
                FindObjectOfType<AnimatorScheduler>().ShowEnemyFist();
            }
            // Show normal cards and hide pick pebbles UI.
            ResetCards();
            _scheduler.HideChain();
            _scheduler.ShowCards();
            
            CardsTurnActivity();
            
            // Show player fist.
            PlayerHolder.Instance.SetupFist();
            _scheduler.ShowPlayerFist();
        }

        private void CardsTurnActivity()
        {
            if (_playerTurn)
            {
                foreach (var card in _cards)
                    card.Enable();
            }
            else
            {
                foreach (var card in _cards)
                    card.Disable();
                StartCoroutine(EnemyHolder.Instance.PickCard());
            }
        }

        private void ResetCards()
        {
            foreach (var card in _cards)
            {
                card.ResetColor();
                card.GetComponent<Animator>().enabled = false;
                card.Enable();
            }
        }

        public void ShowHands()
        {
            _scheduler.ShowHands();
            Invoke(nameof(CountPebbles), 2);
        }

        private void CountPebbles()
        {
            var totalPebbles = PlayerHolder.Instance.PebblesPicked + EnemyHolder.Instance.PebblesPicked;
            
            foreach (var first in _cards.Select(_ => _cards.First(c => c.Value == totalPebbles)))
            {
                var animator = first.GetComponent<Animator>();
                animator.enabled = true;
                animator.Play(first.Value.ToString());
            }
        }

        public void MarkEnemyCard(int value)
        {
            ResetCards();
            var card = _cards.First(c => c.Value == value);
            card.MarkRed();
        }
    }
}