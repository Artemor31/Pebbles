using System.Collections;
using AnimationSchemas;
using UnityEngine;

namespace Infrastructure
{
    public class GameplayWrapper : MonoBehaviour
    {
        [SerializeField] private AnimatorScheduler _animator;
        [SerializeField] private EnemyHolder _enemy;
        [SerializeField] private PlayerHolder _player;

        public IEnumerator ShowOff()
        {
            _animator.ShowHands();
            yield return new WaitForSeconds(1);
            var sum = _player.PebblesPicked + _enemy.PebblesPicked;
          //  _valueCards.PopCard(sum, true);
            yield return new WaitForSeconds(2);
          //  _valueCards.PopCard(sum, false);
            yield return new WaitForSeconds(2);
            _animator.HideCards();
        }
    }
}