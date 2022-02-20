using System;
using UnityEngine;

namespace Gameplay
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private AnimatorScheduler _scheduler;
        [SerializeField] private HandHolder _handHolder;

        private void Start()
        {
            _scheduler.StartChain();
        }

        public void StartCardsState()
        {
            _scheduler.HideChain();
            _scheduler.ShowCards();
        }
    }
}