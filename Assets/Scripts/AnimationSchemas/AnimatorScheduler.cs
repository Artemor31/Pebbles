using System.Collections;
using UnityEngine;

namespace AnimationSchemas
{
    public class AnimatorScheduler : MonoBehaviour
    {
        [SerializeField] private Animator _cards;
        [SerializeField] private Animator _playerHand;
        [SerializeField] private Animator _enemyHand;
        [SerializeField] private Animator _pebblesCards;

        public void ShowValueCards()
        {
            _cards.enabled = true;
            _cards.Play("start");
        }

        public void HideCards()
        {
            _cards.enabled = true;
            _cards.Play("end");
            _playerHand.Play("hide");
            _enemyHand.Play("hide");
        }
        
        public void ShowPlayerFist()
        {
            _playerHand.Play("show");
        }

        public void ShowEnemyFist()
        {
            _enemyHand.Play("show");
        }

        public void ShowHands()
        {
            _enemyHand.Play("showHand");
            _playerHand.Play("showHand");
        }

        public void HidePebbleCards()
        {
            _pebblesCards.enabled = true;
            _pebblesCards.Play("hide");
        }

        public void ShowPebbleCards()
        {
            _pebblesCards.enabled = true;
            _pebblesCards.Play("start");
            DisableAnimator(_pebblesCards);
        }

        private IEnumerator DisableAnimator(Animator animator)
        {
            yield return new WaitForSeconds(3);
            animator.enabled = false;
        }
    }
}
