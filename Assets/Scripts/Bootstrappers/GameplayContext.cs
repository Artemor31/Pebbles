using AnimationSchemas;
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
        public PebbleCardsParent PebbleCardsParent { get; }
        public ValueCardsParent ValueCardsParent { get; }

        public GameplayContext(ICoroutineRunner coroutineRunner, 
                               PlayerHolder player, 
                               EnemyHolder enemy, 
                               PebbleCardsParent pebbleCardsParent, 
                               ValueCardsParent valueCardsParent,
                               AnimatorScheduler animatorScheduler)
        {
            Player = player;
            Enemy = enemy;
            PebbleCardsParent = pebbleCardsParent;
            ValueCardsParent = valueCardsParent;
            _stateMachine = new GameStateMachine(this, coroutineRunner, animatorScheduler);
            _stateMachine.Enter<SetupState>();
        }

    }
}