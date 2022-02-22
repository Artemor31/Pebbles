using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class EnemyHolder : MonoBehaviour
    {
        public static EnemyHolder Instance;
        
        public int PebblesPicked => _pebblesPicked;
        public int PickedCard => _pickedCard;

        [SerializeField] private List<SpriteRenderer> _pebbleInHand;
        private int _pebblesLeft;
        private int _pickedCard;
        private int _pebblesPicked;
        public bool Waiting { get; private set; }

        private void Awake()
        {
            _pebblesLeft = 3;
            Instance = FindObjectOfType<EnemyHolder>();
        }
        
        public void HidePebbles()
        {
            var max = _pebblesLeft + 1;
            _pebblesPicked = Random.Range(0, max);
        }

        public void ChooseCard(bool firstTurn)
        {
            var player = PlayerHolder.Instance;
            
            if (firstTurn)
            {
                var maxInclusive = _pebblesPicked + player.PebblesLeft + 1;
                _pickedCard = Random.Range(_pebblesPicked, maxInclusive);
            }
            else
            {
                var stMax = player.PebblesLeft;

                var min = player.PickedCard <= stMax
                           ? _pebblesPicked
                           : _pebblesPicked + (player.PickedCard - stMax);

                var max = player.PickedCard > 0
                           ? player.PebblesLeft + _pebblesPicked
                           : player.PickedCard + _pebblesPicked;

                _pickedCard = Random.Range(min, max + 1);

                if (_pickedCard == player.PickedCard)
                {
                    _pickedCard = _pickedCard == 6 ? _pickedCard - 1 : _pebblesPicked + 1;
                }
            }
        }

        public void SetupPebblesInHand()
        {
            foreach (var spriteRenderer in _pebbleInHand) 
                spriteRenderer.enabled = false;

            for (var i = 0; i < PebblesPicked; i++) 
                _pebbleInHand[i].enabled = true;
        }

        public IEnumerator ShowFist()
        {
            Waiting = true;
            yield return new WaitForSeconds(Random.Range(3, 8));
            FindObjectOfType<AnimatorScheduler>().ShowEnemyFist();
            Waiting = false;
        }
        
        public IEnumerator PickCard(bool show)
        {
            var seconds = Random.Range(3, 5);
            yield return new WaitForSeconds(seconds);
            ChooseCard(false);
            GameManager.Instance.MarkEnemyCard(_pickedCard);
            StartCoroutine(GameManager.Instance.WaitForCardsEnable());
            if (show)
                GameManager.Instance.ShowHands();
        }
    }
}