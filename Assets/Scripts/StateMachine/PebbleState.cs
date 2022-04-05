using Cards;
using Infrastructure;

namespace StateMachine
{
    public class PebbleState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly PlayerHolder _player;
        private readonly EnemyHolder _enemy;
        private readonly CardsHolder _cards;

        private bool _playerReady;
        private bool _enemyPicked;

        public PebbleState(GameStateMachine stateMachine, PlayerHolder player, EnemyHolder enemy, CardsHolder cards)
        {
            _stateMachine = stateMachine;
            _player = player;
            _enemy = enemy;
            _cards = cards;
        }

        public void Enter()
        {
            ShowCards();
            StartTimers();
            _player.Picked += () => _playerReady = true;
            _enemy.Picked += () => _enemyPicked = true;
        }

        public void Exit()
        {
            ResetTimers();
            HideCards();
        }

        private void StartTimers()
        {
            
        }

        private void ResetTimers()
        {
            
        }

        private void ShowCards()
        {
            _cards.Show();
        }

        private void HideCards()
        {
            _cards.Hide();
        }
    }
}