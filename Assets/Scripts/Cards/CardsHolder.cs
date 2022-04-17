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

        public void ResetView()
        {
            foreach (var decorator in _decorators)
            {
                decorator.SetOpacity(1)
                         .SetGreen(0)
                         .SetRed(0);
            }
        }

        public void ShowValue()
        {
            ResetView();
            _animatorScheduler.ShowPebbleCards();
        }

        public void HideValue()
        {
            _animatorScheduler.HideCards();
        }
        
        public void SetInactive()
        {
            foreach (var decorator in _decorators)
            {
                decorator.SetOpacity(1)
                    .EnableCollider(false);
            }
        }

        public void SetActive()
        {
            foreach (var decorator in _decorators)
            {
                decorator.SetOpacity(0)
                         .EnableCollider(true)
                         .EnableAnimator(false);
            }
        }

        public void SetRed(int value)
        {
            _decorators[value].SetRed(0.6f);
        }

        public void DisableCollider()
        {
            foreach (var decorator in _decorators)
            {
                decorator.EnableCollider(false);
            }
        }
        public void EnableCollider()
        {
            foreach (var decorator in _decorators)
            {
                decorator.EnableCollider(true);
            }
        }

    }
}