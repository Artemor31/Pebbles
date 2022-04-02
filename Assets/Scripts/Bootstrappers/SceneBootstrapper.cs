using UnityEngine;
using Zenject;

namespace Gameplay.Bootstrappers
{
    public class SceneBootstrapper : MonoInstaller
    {
        [SerializeField] private GameManager _gameManager;
            
        public override void InstallBindings()
        {
            Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle();
        }
    }
}