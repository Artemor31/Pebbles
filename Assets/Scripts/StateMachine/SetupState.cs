using AnimationSchemas;
using Bootstrappers;
using Cards;

namespace StateMachine
{
    public class SetupState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly PebblesCardHolder _cards;

        public SetupState(GameStateMachine stateMachine,
                          PebbleCardsParent cardsParent,
                          AnimatorScheduler animator,
                          ICoroutineRunner coroutineRunner)    
        {
            _stateMachine = stateMachine;
            _cards = new PebblesCardHolder(cardsParent.Cards, animator, coroutineRunner);

        }

        public void Enter()
        {
            SetupPlayersView();
            _cards.ResetView();
            _stateMachine.Enter<PebbleState>();
        }

        public void Exit()
        {
            
        }

        private void SetupPlayersView()
        {
            
        }
    }
}