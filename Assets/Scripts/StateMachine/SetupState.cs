namespace StateMachine
{
    public class SetupState : IState
    {
        private readonly GameStateMachine _stateMachine;

        public SetupState(GameStateMachine stateMachine)    
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            SetupPlayersView();
            ResetPebbleCards();
            _stateMachine.Enter<PebbleState>();
        }

        public void Exit()
        {
            
        }

        private void ResetPebbleCards()
        {
            
        }

        private void SetupPlayersView()
        {
            
        }
    }
}