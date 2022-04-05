using System.Collections;
using Cards;
using Infrastructure;
using UnityEngine;
using Zenject;

namespace Bootstrappers
{
    public class SceneBootstrapper : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private PlayerHolder _playerHolder;
        [SerializeField] private EnemyHolder _enemyHolder;
        [SerializeField] private GameplayWrapper _gameplayWrapper;
        [SerializeField] private CardsHolder _cardsHolder;
        
        private GameplayContext _gameplayContext;

        public override void InstallBindings()
        {
            Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle();
            Container.Bind<PlayerHolder>().FromInstance(_playerHolder).AsSingle();
            Container.Bind<GameplayWrapper>().FromInstance(_gameplayWrapper).AsSingle();

            _gameplayContext = new GameplayContext(this, _playerHolder, _enemyHolder, _cardsHolder);
        }

        public void RunCoroutine(IEnumerator coroutine) => 
            StartCoroutine(coroutine);
    }
}