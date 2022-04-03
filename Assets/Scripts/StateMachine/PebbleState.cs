namespace StateMachine
{
    public class PebbleState : IState
    {
        private readonly GameStateMachine _stateMachine;

        public PebbleState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            ShowCards();
            StartTimers();
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
            
        }

        private void HideCards()
        {
            
        }
    }
}