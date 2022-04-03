using StateMachine;

namespace Bootstrappers
{
    public class GameplayContext
    {
        private readonly GameStateMachine _stateMachine;

        public GameplayContext()
        {
            _stateMachine = new GameStateMachine();
            _stateMachine.Enter<SetupState>();
        }
    }
}