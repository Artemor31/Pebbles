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
