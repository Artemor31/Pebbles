using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public class AnimatorScheduler : MonoBehaviour
    {
        [SerializeField] private Animator _pebbles;
        [SerializeField] private Animator _handIcon;
        [SerializeField] private Animator _backPanel;
        [SerializeField] private Animator _cards;
        [SerializeField] private Animator _playerHand;
        [SerializeField] private Animator _enemyHand;

        public void StartChain()
        {
            _handIcon.enabled = true;
            _backPanel.Play("start");
        }

        public void HideChain()
        {
            _handIcon.enabled = true;
            _pebbles.Play("hide");
            _backPanel.Play("hide");
            _handIcon.Play("hide");
        }

        public void ShowCards()
        {
            _cards.enabled = true;
            _cards.Play("start");
        }

        public void HideCards()
        {
            _cards.enabled = true;
            _cards.Play("end");
            _playerHand.Play("hide");
            _enemyHand.Play("hide");
        }
        
        public void ShowPlayerFist()
        {
            _playerHand.Play("show");
        }

        public void ShowEnemyFist()
        {
            _enemyHand.Play("show");
        }

        public void ShowHands()
        {
            _enemyHand.Play("showHand");
            _playerHand.Play("showHand");
        }
    }
}
