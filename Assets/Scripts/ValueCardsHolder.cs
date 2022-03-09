using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay
{
    public class ValueCardsHolder : MonoBehaviour
    {
        [SerializeField] private List<Card> _cards;

        public void PreAnimate()
        {
            foreach (var card in _cards)
            {
                card.SetClear()
                    .SetAnimator(true)
                    .SetClickable(false);
            }
        }

        public void PrePlayerPick()
        {
            foreach (var card in _cards)
            {
                card.SetOpacity(false)
                    .SetClickable(true)
                    .SetAnimator(false);
            }
        }

        public void PreAiPick()
        {
            foreach (var card in _cards)
            {
                card.SetClickable(false)
                    .SetOpacity(true);
            }
        }

        public void MarkAiCard(int value)
        {
            _cards.First(c => c.Value == value)
                  .SetClickable(false)
                  .SetRed();
        }
        
        public void PopCard(int value, bool up)
        {
            var card = _cards.First(c => c.Value == value);
            var animator = card.GetComponent<Animator>();
            animator.enabled = true;
            animator.SetFloat("speed", up ? 1 : -1);
            animator.Play(card.Value.ToString());
        }

        public void Clickable(bool value)
        {
            foreach (var card in _cards) 
                card.SetClickable(value);
        }
    }
}