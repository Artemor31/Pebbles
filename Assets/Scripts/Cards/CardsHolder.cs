using System.Linq;
using AnimationSchemas;

namespace Cards
{
    public abstract class CardsHolder
    {
        protected readonly ICard[] _cards;
        protected readonly CardDecorator[] _decorators;
        protected readonly AnimatorScheduler _animatorScheduler;

        protected CardsHolder(ICard[] cards, AnimatorScheduler animatorScheduler)
        {
            _cards = cards;
            _animatorScheduler = animatorScheduler;
            _decorators = _cards.Select(c => c.Decorator)
                                .ToArray();
        }

        private void SetRed(int value) => _decorators[value].SetRed(0.6f);

        private void HideValue() => _animatorScheduler.HideCards();

        protected void ResetView()
        {
            foreach (var decorator in _decorators)
            {
                decorator.SetVisibility(1)
                         .SetGreen(0)
                         .SetRed(0)
                         .EnableCollider(false);
            }
        }

        private void SetActive()
        {
            foreach (var decorator in _decorators)
            {
                decorator.SetVisibility(0)
                         .EnableCollider(true)
                         .EnableAnimator(false);
            }
        }

        private void SetInactive()
        {
            foreach (var decorator in _decorators)
            {
                decorator.SetVisibility(1)
                         .EnableCollider(false);
            }
        }
    }
}