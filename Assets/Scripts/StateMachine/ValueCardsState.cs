using System.Collections;
using AnimationSchemas;
using Bootstrappers;
using Cards;
using Infrastructure;
using Utils;

namespace StateMachine
{
    public class ValueCardsState : IState
    {
        private readonly AnimatorScheduler _animator;
        private readonly GameTimer _timer;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly ValueCardsHolder _valueCardsHolder;
        
        public ValueCardsState(AnimatorScheduler animator,
                               ValueCardsParent cardsParent,
                               GameTimer timer,
                               ICoroutineRunner coroutineRunner)
        {
            _animator = animator;
            _timer = timer;
            _coroutineRunner = coroutineRunner;
            _valueCardsHolder = new ValueCardsHolder(cardsParent.Cards, animator);
        }
        
        public void Enter()
        {
            ShowCards();
            _coroutineRunner.RunCoroutine(WaitForStage());
            
            if (GameplayContext.PlayerTurn)
                StartPlayerTurn();
            else
                StartEnemyTurn();
        }

        private IEnumerator WaitForStage()
        {
            yield return null;
        }
        
        private void StartEnemyTurn()
        {
            
        }

        private void StartPlayerTurn()
        {
            _timer.StartPlayer();
            _valueCardsHolder.ShowValueCards();
        }

        public void Exit()
        {
            
        }

        private void ShowCards()
        {
        }
    }
}