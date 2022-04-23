using AnimationSchemas;
using Cards;

namespace StateMachine
{
    public class ValueCardsState : IState
    {
        private readonly AnimatorScheduler _animator;
        private readonly ValueCardsHolder _valueCardsHolder;

        public ValueCardsState(AnimatorScheduler animator,
                               ValueCardsParent cardsParent)
        {
            _animator = animator;
            _valueCardsHolder = new ValueCardsHolder(cardsParent.Cards, animator);
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
            _valueCardsHolder.EnableCollider();
            _valueCardsHolder.DisableAnimators();
            _animator.ShowValueCards();
        }
    }
}