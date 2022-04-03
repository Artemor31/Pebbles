using Infrastructure;
using UnityEngine;
using Zenject;

namespace Bootstrappers
{
    public class SceneBootstrapper : MonoInstaller
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private PlayerHolder _playerHolder;
        [SerializeField] private GameplayWrapper _gameplayWrapper;
        
        private GameplayContext _gameplayContext;

        public override void InstallBindings()
        {
            Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle();
            Container.Bind<PlayerHolder>().FromInstance(_playerHolder).AsSingle();
            Container.Bind<GameplayWrapper>().FromInstance(_gameplayWrapper).AsSingle();

            _gameplayContext = new GameplayContext();
        }
    }
}