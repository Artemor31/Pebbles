namespace StateMachine
{
    public class SetupValueCardsState : IState
    {
        private const int Delay = 2;
        private readonly GameStateMachine _stateMachine;

        public SetupValueCardsState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _stateMachine.EnterAfterDelay<ValueCardsState>(Delay);
        }

        public void Exit()
        {
            
        }
    }
}