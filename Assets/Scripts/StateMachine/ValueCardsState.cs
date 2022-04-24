using System.Collections;
using AnimationSchemas;
using Bootstrappers;
using Cards;
using Infrastructure;
using UnityEngine;
using Utils;

namespace StateMachine
{
    public class ValueCardsState : IState
    {
        private readonly GameTimer _timer;
        private readonly AnimatorScheduler _animator;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly EnemyHolder _enemyHolder;
        private readonly ValueCardsHolder _valueCardsHolder;
        
        public ValueCardsState(AnimatorScheduler animator,
                               ValueCardsParent cardsParent,
                               GameTimer timer,
                               ICoroutineRunner coroutineRunner,
                               EnemyHolder enemyHolder)
        {
            _animator = animator;
            _timer = timer;
            _coroutineRunner = coroutineRunner;
            _enemyHolder = enemyHolder;
            _valueCardsHolder = new ValueCardsHolder(cardsParent.Cards, animator);
        }
        
        public void Enter()
        {
            _coroutineRunner.RunCoroutine(WaitForCards());
            
            if (GameplayContext.PlayerTurn)
                StartPlayerTurn();
            else
                StartEnemyTurn();
        }

        public void Exit() { }

        private void StartEnemyTurn()
        {
            _timer.StartAI();
            _coroutineRunner.RunCoroutine(_enemyHolder.StartChoosingCards(GameplayContext.PlayerTurn));
        }

        private void StartPlayerTurn()
        {
            _timer.StartPlayer();
        }

        private IEnumerator WaitForCards()
        {
            yield return new WaitForSeconds(1f);
        }
    }
}