﻿using AnimationSchemas;

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
}