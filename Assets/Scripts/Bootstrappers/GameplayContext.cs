using StateMachine;
using UnityEditor.SearchService;

namespace Bootstrappers
{
    public class GameplayContext
    {
        private readonly GameStateMachine _stateMachine;

        public GameplayContext(ICoroutineRunner coroutineRunner)
        {
            _stateMachine = new GameStateMachine(this, coroutineRunner);
            _stateMachine.Enter<SetupState>();
        }
    }
}