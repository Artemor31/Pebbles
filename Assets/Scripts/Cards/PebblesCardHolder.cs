using AnimationSchemas;

namespace Cards
{
    public class PebblesCardHolder : CardsHolder
    {
        public PebblesCardHolder(ICard[] cards, AnimatorScheduler animatorScheduler) 
            : base(cards, animatorScheduler) { }
        
        public void ShowPebbles()
        {
            ResetView();
            _animatorScheduler.ShowPebbleCards();
        }

        public void HidePebbles()
        {
            _animatorScheduler.HidePebbleCards();
        }
        
    }
    
    public class ValueCardsHolder : CardsHolder
    {
        public ValueCardsHolder(ICard[] cards, AnimatorScheduler animatorScheduler)
            : base(cards, animatorScheduler) { }
        
        public void PopOut(int value)
        {
            AnimatePop(value, true);
        }

        public void PopIn(int value)
        {
            AnimatePop(value, false);
        }

        private void AnimatePop(int value, bool up)
        {
            _decorators[value].Pop(value, up);
        }
    }
}