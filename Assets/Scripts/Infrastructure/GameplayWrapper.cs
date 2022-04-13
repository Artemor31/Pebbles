﻿using System.Collections;
using AnimationSchemas;
using Cards;
using UnityEngine;
using Utils;
using Zenject;

namespace Infrastructure
{
    public class GameplayWrapper : MonoBehaviour
    {
        [SerializeField] private GameManager _manager;
        [SerializeField] private AnimatorScheduler _animator;
        [SerializeField] private GameTimer _timer;
        [SerializeField] private EnemyHolder _enemy;
        [SerializeField] private PlayerHolder _player;
        
        private GameManager _gameManager;

        [Inject]
        public void Constructor(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        
        private void OnEnable()
        {
            _enemy.ValuePicked += AiPickedValue;
            _player.PickedValue += PlayerPickedValue;
        }

        public void StartPebblePickStage()
        {
           // _pebbleCards.PrePick();
            //_animator.ShowPebbleCards();
            //_timer.StartPlayer();
            //_timer.StartAI();
          //  StartCoroutine(_enemy.ChoosingPebbles());
        }

        public void PlayerPickedPebbles(int value)
        {
            _player.PebblesPicked = value;
            _timer.StopPlayer();
            _animator.HidePebbleCards();
            _player.ShowFist();
           // _pebbleCards.PreAnimate();
        }

        public void StartCardsStage()
        {
            _gameManager.AiReady = false;
            _gameManager.PlayerReady = false;
            
           // _valueCards.PreAnimate();
            _animator.ShowCards();
            SetupField();
        }

        private void SetupField()
        {
            if (_gameManager.PlayerTurn)
            {
              //  _valueCards.PrePlayerPick();
                _timer.StartPlayer();
            }
            else
            {
               // _valueCards.PreAiPick();
                _timer.StartAI();
                StartCoroutine(_enemy.PickingCard());
            }
        }

        private void AiPickedValue(int value)
        {
            _gameManager.AiReady = true;
           // _valueCards.MarkAiCard(_enemy.PickedCard);
           // _valueCards.PrePlayerPick();
            _timer.StopAI();
            
            if (_manager.PlayerReady == false)
            {
                _manager.PlayerTurn = !_manager.PlayerTurn;
                SetupField();
            }
        }

        private void PlayerPickedValue(int value)
        {
            _manager.PlayerReady = true;
            _player.CardValue = value;
          //  _valueCards.PrePlayerPick();
          //  _valueCards.Clickable(false);
            _timer.StopPlayer();
            
            if (_manager.AiReady == false)
            {
                _manager.PlayerTurn = !_manager.PlayerTurn;
                SetupField();
            }
        }

        public IEnumerator ShowOff()
        {
            _animator.ShowHands();
            yield return new WaitForSeconds(1);
            var sum = _player.PebblesPicked + _enemy.PebblesPicked;
          //  _valueCards.PopCard(sum, true);
            yield return new WaitForSeconds(2);
          //  _valueCards.PopCard(sum, false);
            yield return new WaitForSeconds(2);
            _animator.HideCards();
        }

        public Result CheckResult(int sum)
        {
            if (_player.CardValue == sum)
            {
                return Result.Player;
            }

            if (_enemy.PickedCard == sum)
                return Result.Ai;
            
            return Result.Draw;
        }
    }
}