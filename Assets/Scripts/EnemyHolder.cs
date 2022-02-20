using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class EnemyHolder : MonoBehaviour
    {
        public static EnemyHolder Instance;

        [SerializeField] private List<SpriteRenderer> _pebbleInHand;
        public int PebblesHidden { get; private set; }
        
        private int _pebblesLeft;
        private int _cardValuePicked;
        

        private void Start()
        {
            _pebblesLeft = 3;
            Instance = FindObjectOfType<EnemyHolder>();
        }
        
        public void HidePebbles()
        {
            var max = _pebblesLeft + 1;
            PebblesHidden = Random.Range(0, max);
        }

        public void SetupPebblesInHand()
        {
            foreach (var spriteRenderer in _pebbleInHand)
            {
                spriteRenderer.enabled = false;
            }

            for (int i = 0; i < PebblesHidden; i++)
            {
                _pebbleInHand[i].enabled = true;
            }
        }

        public IEnumerator ShowFist()
        {
            yield return new WaitForSeconds(Random.Range(3, 8));
            FindObjectOfType<AnimatorScheduler>().ShowEnemyFist();
        }
    }
}