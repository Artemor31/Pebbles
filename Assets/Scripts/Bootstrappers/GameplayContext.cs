using Cards;
using Infrastructure;
using StateMachine;

namespace Bootstrappers
{
    public class GameplayContext
    {
        private readonly GameStateMachine _stateMachine;

        public PlayerHolder Player { get; }
        public EnemyHolder Enemy { get; }
        public CardsHolder CardsHolder { get; }

        public GameplayContext(ICoroutineRunner coroutineRunner, PlayerHolder player, EnemyHolder enemyEnemy, CardsHolder cardsHolder)
        {
            Player = player;
            Enemy = enemyEnemy;
            CardsHolder = cardsHolder;
            _stateMachine = new GameStateMachine(this, coroutineRunner);
            _stateMachine.Enter<SetupState>();
        }
    }
}