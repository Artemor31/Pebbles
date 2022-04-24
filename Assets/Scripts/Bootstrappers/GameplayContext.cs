using StateMachine;
using UnityEngine;

namespace Bootstrappers
{
    public class GameplayContext 
    {
        private readonly GameStateMachine _stateMachine;
        public static bool PlayerTurn;
        
        public GameplayContext(GameStateMachine stateMachine)
        {
            PlayerTurn = Random.Range(0, 2) == 0;
            _stateMachine = stateMachine;
            _stateMachine.Init();
            _stateMachine.Enter<SetupState>();
        }
    }
}