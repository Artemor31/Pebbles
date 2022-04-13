using System.Collections;
using AnimationSchemas;
using Infrastructure;
using UnityEngine;
using Zenject;
using Cards;
using Factory;
using StateMachine;

namespace Bootstrappers
{
    public class SceneBootstrapper : MonoInstaller, ICoroutineRunner, IInitializable
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
            BindGameManager();
            BindPlayers();
            BindSingletons();
            BindGameInfrastructure();
            BindStates();
            
            _gameplayContext = new GameplayContext(Container.Resolve<GameStateMachine>());
        }

        private void BindStates()
        {
            Container.Bind<SetupState>().AsSingle().NonLazy();
            Container.Bind<PebbleState>().AsSingle().NonLazy();
            Container.Bind<SetupValueCardsState>().AsSingle().NonLazy();
            Container.Bind<ValueCardsState>().AsSingle().NonLazy();
        }

        private void BindGameInfrastructure()
        {
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
            Container.Bind<GameStateMachine>().AsSingle().NonLazy();
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
        }

        private void BindSingletons()
        {
            Container.Bind<PebbleCardsParent>().FromInstance(_pebbleCardsParent).AsSingle();
            Container.Bind<ValueCardsParent>().FromInstance(_valueCardsParent).AsSingle();
            Container.Bind<AnimatorScheduler>().FromInstance(_animatorScheduler).AsSingle();
            Container.Bind<GameplayWrapper>().FromInstance(_gameplayWrapper).AsSingle();
        }

        private void BindPlayers()
        {
            Container.Bind<PlayerHolder>().FromInstance(_playerHolder).AsSingle();
            Container.Bind<EnemyHolder>().FromInstance(_enemyHolder).AsSingle();
        }

        private void BindGameManager()
        {
            Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle();
        }

        public void Initialize() {} 

        public void RunCoroutine(IEnumerator coroutine) => 
            StartCoroutine(coroutine);
    }
}