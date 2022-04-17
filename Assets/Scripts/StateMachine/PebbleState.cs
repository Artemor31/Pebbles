using AnimationSchemas;
using Infrastructure;
using Cards;
using Unity.VisualScripting;
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
                           AnimatorScheduler animator,GameTimer timer)
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
            _player.Picked += PlayerValuePicked;
            _enemy.Picked += EnemyValuePicked;
            _enemy.StartChoosePebbles();
        }

        public void Exit()
        {
            ResetTimers();
            HideCards();
        }

        private void CheckNewStateEntry()
        {
            if (_playerReady && _enemyPicked)
                _stateMachine.Enter<SetupValueCardsState>();
        }

        private void PlayerValuePicked()
        {
            _playerReady = true;
            CheckNewStateEntry();
        }

        private void EnemyValuePicked()
        {
            _enemyPicked = true;
            CheckNewStateEntry();
        }

        private void StartTimers()
        {
            _timer.StartAI();
            _timer.StartPlayer();
        }

        private void ResetTimers()
        {
            _timer.StopAI();
            _timer.StopPlayer();
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
        
        public void PlayerPickedPebbles(int value)
        {
            _player.PebblesPicked = value;
            _animator.HidePebbleCards();
            _player.ShowFist();
        }
    }
}