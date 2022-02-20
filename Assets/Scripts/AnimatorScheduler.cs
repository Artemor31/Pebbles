using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public class AnimatorScheduler : MonoBehaviour
    {
        [SerializeField] private Animator _pebbles;
        [SerializeField] private Animator _handIcon;
        [SerializeField] private Animator _backPanel;
        [SerializeField] private Animator _cards;
        [SerializeField] private Animator _playerHand;
        [SerializeField] private Animator _enemyHand;

        public void StartChain()
        {
            _handIcon.enabled = true;
            _pebbles.Play("start");
            _handIcon.Play("start");

            var length = _handIcon.GetCurrentAnimatorStateInfo(0).length;
            
            Invoke(nameof(DisableAnimator), length * 1.1f);
        }

        public void HideChain()
        {
            _handIcon.enabled = true;
            _pebbles.Play("hide");
            _backPanel.Play("hide");
            _handIcon.Play("hide");
        }

        public void ShowCards()
        {
            _cards.enabled = true;
            _cards.Play("start");
            Invoke(nameof(DisableAnimatorCards), 2);
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

        private void DisableAnimatorCards()
        {
            _cards.enabled = false;
        }
        
        private void DisableAnimator()
        {
            _handIcon.enabled = false;
        }
    }
}
