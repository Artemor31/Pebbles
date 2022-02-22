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
        public bool PlayerTurn => _playerTurn;
        
        [SerializeField] private AnimatorScheduler _scheduler;
        [SerializeField] private HandHolder _handHolder;
        [SerializeField] private List<Card> _cards;

        private int _playerPickValue;
        private bool _playerTurn;
        private IEnumerator _waitForFist;

        private void Start()
        {
            Instance = FindObjectOfType<GameManager>();
            
            if (Random.Range(0, 2) == 0) 
                _playerTurn = false;
            
            StartGameplay();
        }

        private void StartGameplay()
        {
            
            _playerTurn = !_playerTurn;

            _scheduler.StartChain();
            StartPebbleChooseState();
        }

        private void StartPebbleChooseState()
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
            foreach (var card in _cards)
                card.Disable(true);

            StartCoroutine(_playerTurn 
                           ? WaitForCardsEnable() 
                           : EnemyHolder.Instance.PickCard(false));
        }

        public IEnumerator WaitForCardsEnable()
        {
            yield return new WaitForSeconds(2);
            foreach (var card in _cards)
                card.Enable();
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
            Card card = null;
            foreach (var first in _cards.Select(_ => _cards.First(c => c.Value == totalPebbles)))
            {
                card = first;
                PopCard(card, 1);
                break;
            }

            StartCoroutine(RestartGame(card));
        }
        
        private IEnumerator RestartGame(Card popup)
        {
            yield return new WaitForSeconds(2);
            PopCard(popup, -1);
            yield return new WaitForSeconds(4);
            _scheduler.HideCards();
            var findObjectsOfType = FindObjectsOfType<Pebble>();
            StartGameplay();
        }
        
        private void PopCard(Card card, int speed)
        {
            var animator = card.GetComponent<Animator>();
            animator.enabled = true;
            animator.SetFloat("speed", speed);
            animator.Play(card.Value.ToString());
        }


        public void DisableCardsWithoutColorize()
        {
            foreach (var card in _cards) card.Disable(false);
        }

        public void MarkEnemyCard(int value)
        {
            //ResetCards();
            var card = _cards.First(c => c.Value == value);
            card.MarkRed();
        }
    }
}