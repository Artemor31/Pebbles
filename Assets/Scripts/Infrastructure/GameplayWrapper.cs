using System.Collections;
using AnimationSchemas;
using Cards;
using UnityEngine;
using Utils;
using Zenject;

namespace Infrastructure
{
    public class GameplayWrapper : MonoBehaviour
    {
        [SerializeField] private AnimatorScheduler _animator;
        [SerializeField] private GameTimer _timer;
        [SerializeField] private EnemyHolder _enemy;
        [SerializeField] private PlayerHolder _player;
        
        private void OnEnable()
        {
            _enemy.ValuePicked += AiPickedValue;
            _player.PickedValue += PlayerPickedValue;
        }


        private void AiPickedValue(int value)
        {
            _timer.StopAI();
        }

        private void PlayerPickedValue(int value)
        {
            _player.CardValue = value;
            _timer.StopPlayer();
        }

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