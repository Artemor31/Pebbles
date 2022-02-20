using System;
using System.Collections.Generic;
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

        private float _playerPickValue;
        private bool _playerTurn;

        private void Start()
        {
            Instance = FindObjectOfType<GameManager>();
            
            if (Random.Range(0, 2) == 0) 
                _playerTurn = true;
            
            _scheduler.StartChain();

            StartCoroutine(EnemyHolder.Instance.ShowFist());
        }

        public void StartCardsState()
        {
            _scheduler.HideChain();
            _scheduler.ShowCards();
            if (_playerTurn)
            {
                
            }
            else
            {
                
            }
            PlayerHolder.Instance.SetupFist();
            EnemyHolder.Instance.HidePebbles();
            _scheduler.ShowPlayerFist();
        }

        public void ShowHands()
        {
            EnemyHolder.Instance.SetupPebblesInHand();
            _scheduler.ShowHands();
            Invoke(nameof(CountPebbles), 2);
        }

        private void CountPebbles()
        {
            
        }

        public void PickedCard(int value)
        {
            _playerPickValue = value;
        }
    }
}