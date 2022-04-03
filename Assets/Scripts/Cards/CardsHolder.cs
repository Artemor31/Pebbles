using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    public class CardsHolder
    {
        private readonly List<ICard> _cards;
        private readonly List<CardDecorator> _decorators;

        public CardsHolder(List<ICard> cards)
        {
            _cards = cards;
            _decorators = _cards.Select(c => c.Decorator)
                                .ToList();
        }

        public void ResetView()
        {
            foreach (var decorator in _decorators)
            {
                decorator.SetOpacity(0)
                         .SetGreen(0)
                         .SetRed(0);
            }
        }

        public void Show()
        {
            ResetView();

        }

        public void Hide()
        {

        }

        public void PopOut(int value)
        {

        }

        public void PopIn(int value)
        {

        }

        public void SetInactive()
        {

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
            _decorators[value].SetRed(value);
        }

        public void SetGreen(int value)
        {
            _decorators[value].SetGreen(value);
        }

        private void AnimatePop(int value, bool up)
        {
            _decorators[value].Pop(value, up);
        }
    }
}