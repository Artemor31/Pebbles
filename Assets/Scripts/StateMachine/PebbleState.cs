using System;
using AnimationSchemas;
using Infrastructure;
using Cards;
using Utils;

namespace StateMachine
{
    public class PebbleState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly PlayerHolder _player;
        private readonly EnemyHolder _enemy;
        private readonly AnimatorScheduler _animator;
        private readonly PebbleCardsParent _cardsParent;
        private readonly PebblesCardHolder _cards;
        private readonly GameTimer _timer;

        private bool _playerReady;
        private bool _enemyPicked;

        public PebbleState(GameStateMachine stateMachine, 
                           PlayerHolder player,
                           EnemyHolder enemy,
                           PebbleCardsParent cardsParent, 
                           AnimatorScheduler animator,
                           GameTimer timer)
        {
            _stateMachine = stateMachine;
            _player = player;
            _enemy = enemy;
            _animator = animator;
            _timer = timer;
            _cards = new PebblesCardHolder(cardsParent.Cards, animator);
        }

        public void Enter()
        {
            ShowCards();
            StartTimers();
            _enemy.StartChoosePebbles(OnEnemyPickedPebbles);
        }

        public void Exit()
        {
            _timer.StopPlayer();
            HideCards();
        }

        public void PlayerPickedPebbles(int value)
        {
            _playerReady = true;
            _player.PebblesPicked = value;
            _animator.HidePebbleCards();
            _player.ShowFist();
            CheckNewStateEntry();
        }

        public void OnEnemyPickedPebbles()
        {
            _enemyPicked = true;
            CheckNewStateEntry();
        }

        private void CheckNewStateEntry()
        {
            if (_playerReady && _enemyPicked)
                _stateMachine.Enter<SetupValueCardsState>();
        }

        private void StartTimers()
        {
            _timer.StartAI();
            _timer.StartPlayer();
        }

        private void ShowCards()
        {
            _cards.ShowPebbles();
            _cards.EnableCollider();
        }

        private void HideCards()
        {
            _cards.HidePebbles();
        }
    }
}