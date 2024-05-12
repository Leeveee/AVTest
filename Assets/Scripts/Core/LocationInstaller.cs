using HealthBar;
using ScriptableObjects;
using StateMachine;
using UI;
using UnityEngine;
using Zenject;

namespace Core
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField]
        private HealthBarCanvas _healthBarCanvas; 
        [SerializeField]
        private CanvasManager _canvasManager;
        [SerializeField]
        private CameraSwitcher _cameraSwitcher; 
        [SerializeField]
        private GameManager _gameManager;
        [SerializeField]
        private GameConfig _gameConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<StateFactory>().AsSingle();
            Container.Bind<Registry>().AsSingle();
            
            Container.Bind<HealthBarCanvas>().FromInstance(_healthBarCanvas).AsSingle();
            Container.Bind<CanvasManager>().FromInstance(_canvasManager).AsSingle();
            Container.Bind<CameraSwitcher>().FromInstance(_cameraSwitcher).AsSingle();
            Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle();
            Container.Bind<GameConfig>().FromScriptableObject(_gameConfig).AsSingle();
        }
    }
}