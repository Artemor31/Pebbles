using System;
using UnityEngine;

namespace Gameplay
{
    public class AnimatorScheduler : MonoBehaviour
    {
        [SerializeField] private Animator _pebbles;
        [SerializeField] private Animator _handIcon;

        public void StartChain()
        {
            _handIcon.enabled = true;
            _pebbles.Play("start");
            _handIcon.Play("start");

            var length = _handIcon.GetCurrentAnimatorStateInfo(0).length;
            
            Invoke(nameof(DisableAnimator), length * 1.1f);
        }

        private void DisableAnimator()
        {
            _handIcon.enabled = false;
        }

        private void Start()
        {
            StartChain();
        }
    }
}
