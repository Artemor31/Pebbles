using System.Collections;
using AnimationSchemas;
using Infrastructure;
using UnityEngine;
using Zenject;
using Cards;

namespace Bootstrappers
{
    public class SceneBootstrapper : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private PlayerHolder _playerHolder;
        [SerializeField] private EnemyHolder _enemyHolder;
        [SerializeField] private GameplayWrapper _gameplayWrapper;
        [SerializeField] private PebbleCardsParent _pebbleCardsParent;
        [SerializeField] private ValueCardsParent _valueCardsParent;
        [SerializeField] private AnimatorScheduler _animatorScheduler;
        
        private GameplayContext _gameplayContext;

        public override void InstallBindings()
        {
            Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle();
            Container.Bind<PlayerHolder>().FromInstance(_playerHolder).AsSingle();
            Container.Bind<GameplayWrapper>().FromInstance(_gameplayWrapper).AsSingle();

            _gameplayContext = new GameplayContext(this, _playerHolder, _enemyHolder, _pebbleCardsParent, _valueCardsParent, _animatorScheduler);
        }

        public void RunCoroutine(IEnumerator coroutine) => 
            StartCoroutine(coroutine);
    }
}