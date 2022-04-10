using StateMachine;

namespace Bootstrappers
{
    public class GameplayContext 
    {
        private readonly GameStateMachine _stateMachine;
        
        public GameplayContext(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _stateMachine.Init();
            _stateMachine.Enter<SetupState>();
        }
    }
}