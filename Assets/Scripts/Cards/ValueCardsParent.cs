using UnityEngine;

namespace Cards
{
    public class ValueCardsParent : MonoBehaviour, ICardsParent
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private ValueCard[] _cards;
        
        public Animator Animator => _animator;
        public ICard[] Cards => _cards;
    }
}