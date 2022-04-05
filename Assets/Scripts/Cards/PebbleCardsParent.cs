using UnityEngine;

namespace Cards
{
    public class PebbleCardsParent : MonoBehaviour, ICardsParent
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private PebbleCard[] _cards;
        
        public Animator Animator => _animator;
        public ICard[] Cards => _cards;
    }
}