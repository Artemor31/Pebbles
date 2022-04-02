using StateMachine;
using UnityEngine;

namespace Bootstrappers
{
    public class GameStarter : MonoBehaviour
    {
        private GameStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = new GameStateMachine();
            _stateMachine.Enter<SetupState>();
        }
    }
}