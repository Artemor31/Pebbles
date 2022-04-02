using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField] private int _valueTimeLimit;
        [SerializeField] private float _step;
        [SerializeField] private Image _playerTimer;
        [SerializeField] private Image _enemyTimer;

        public void StartPlayer()
        {
            _playerTimer.gameObject.SetActive(true);
            _playerTimer.fillAmount = 1;
            StartCoroutine(TickPlayer());
        }

        private IEnumerator TickPlayer()
        {
            float count = _valueTimeLimit;
            var amountPart = 1 / count * _step;
            while (count > 0)
            {
                yield return new WaitForSeconds(_step);
                count -= 1 * _step;
                _playerTimer.fillAmount -= amountPart;
            }
        }
        
        private IEnumerator TickEnemy()
        {
            float count = _valueTimeLimit;    
            var amountPart = 1 / count * _step;
            
            while (count > 0)
            {
                yield return new WaitForSeconds(_step);
                count -= 1 * _step;
                _enemyTimer.fillAmount -= amountPart;
            }
        }

        public void StopPlayer()
        {
            StopCoroutine(TickPlayer());
            _playerTimer.gameObject.SetActive(false);
        }
        
        public void StartAI()
        {
            _enemyTimer.gameObject.SetActive(true);
            _enemyTimer.fillAmount = 1;
            StartCoroutine(TickEnemy());
        }

        public void StopAI()
        {
            StopCoroutine(TickEnemy());
            _enemyTimer.gameObject.SetActive(false);
        }
    }
}