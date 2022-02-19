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
            _pebbles.Play("start");
            _handIcon.Play("start");
        }

        private void Start()
        {
            StartChain();
        }
    }
}
