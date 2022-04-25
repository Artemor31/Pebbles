using System.Collections;
using AnimationSchemas;
using Bootstrappers;
using UnityEngine;

namespace Cards
{
    public class PebblesCardHolder : CardsHolder
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public PebblesCardHolder(ICard[] cards, AnimatorScheduler animatorScheduler, ICoroutineRunner coroutineRunner) 
            : base(cards, animatorScheduler)
        {
            _coroutineRunner = coroutineRunner;
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

        private IEnumerator WaitForAnimaion()
        {
            yield return new WaitForSeconds(1);
            
        }
        
    }
}