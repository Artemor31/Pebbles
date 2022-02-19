using UnityEngine;

namespace Gameplay
{
    public class AnimationChain : MonoBehaviour
    {
        [SerializeField] private Animator _nextAnimator;

        public void StartNext()
        {
            _nextAnimator.Play("start");
        }
    }
}