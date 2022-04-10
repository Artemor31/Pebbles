using AnimationSchemas;
using Cards;

namespace StateMachine
{
    public class ValueCardsState : IState
    {
        public ValueCardsState(AnimatorScheduler animator,
                               ValueCardsParent cardsParent)
        {
            
        }
        
        public void Enter()
        {
            ShowCards();
        }

        public void Exit()
        {
            
        }

        private void ShowCards()
        {
            
        }
    }
}