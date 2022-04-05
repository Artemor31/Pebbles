using System.Linq;
using AnimationSchemas;

namespace Cards
{
    public class CardsHolder
    {
        private readonly ICard[] _cards;
        private readonly CardDecorator[] _decorators;
        private readonly AnimatorScheduler _animatorScheduler;
        

        public CardsHolder(ICard[] cards, AnimatorScheduler animatorScheduler)
        {
            _cards = cards;
            _decorators = _cards.Select(c => c.Decorator).ToArray();
            _animatorScheduler = animatorScheduler;
        }

        public void ResetView()
        {
            foreach (var decorator in _decorators)
            {
                decorator.SetOpacity(1)
                         .SetGreen(0)
                         .SetRed(0);
            }
        }

        public void ShowPebbles()
        {
            ResetView();
            _animatorScheduler.ShowPebbleCards();
        }

        public void HidePebbles()
        {
            _animatorScheduler.HidePebbleCards();
        }

        public void ShowValue()
        {
            ResetView();
            _animatorScheduler.ShowCards();
        }

        public void HideValue()
        {
            _animatorScheduler.HideCards();
        }

        public void PopOut(int value)
        {
            AnimatePop(value, true);
        }

        public void PopIn(int value)
        {
            AnimatePop(value, false);
        }

        public void SetInactive()
        {
            foreach (var decorator in _decorators)
            {
                decorator.SetOpacity(0)
                    .EnableCollider(false);
            }
        }

        public void SetActive()
        {
            foreach (var decorator in _decorators)
            {
                decorator.SetOpacity(1)
                         .EnableCollider(true)
                         .EnableAnimator(false);
            }
        }

        public void SetRed(int value)
        {
            _decorators[value].SetRed(0.6f);
        }
        

        private void AnimatePop(int value, bool up)
        {
            _decorators[value].Pop(value, up);
        }
    }
}