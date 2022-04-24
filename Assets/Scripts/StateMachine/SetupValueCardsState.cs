using Cards;

namespace StateMachine
{
    public class SetupValueCardsState : IState
    {
        private const int Delay = 2;
        private readonly GameStateMachine _stateMachine;
        private ValueCardsHolder _valueCardsHolder;

        public SetupValueCardsState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _valueCardsHolder.ShowValueCards();
            _stateMachine.EnterAfterDelay<ValueCardsState>(Delay);
        }

        public void Exit() { }
    }
}