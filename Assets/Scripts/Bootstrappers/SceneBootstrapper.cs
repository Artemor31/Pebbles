using System;
using Infrostructure;
using UnityEngine;
using Zenject;

namespace Bootstrappers
{
    public class SceneBootstrapper : MonoInstaller
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private PlayerHolder _playerHolder;
            
        public override void InstallBindings()
        {
            Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle();
            Container.Bind<PlayerHolder>().FromInstance(_playerHolder).AsSingle();
            
            
        }
    }
}