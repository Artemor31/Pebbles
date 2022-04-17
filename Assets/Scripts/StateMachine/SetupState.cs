using AnimationSchemas;
using Cards;
using UnityEngine;

namespace StateMachine
{
    public class SetupState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly PebblesCardHolder _cards;

        public SetupState(GameStateMachine stateMachine,PebbleCardsParent cardsParent,AnimatorScheduler animator)    
        {
            _stateMachine = stateMachine;
            _cards = new PebblesCardHolder(cardsParent.Cards, animator);

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
            _cards.ResetView();
            _cards.DisableCollider();
        }

        private void SetupPlayersView()
        {
            
        }
    }
}