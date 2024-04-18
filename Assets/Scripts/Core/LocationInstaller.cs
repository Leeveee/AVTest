using Components;
using HealthBar;
using StateMachine;
using UnityEngine;
using Zenject;

namespace Core
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField]
        private HealthBarCanvas _healthBarCanvas;

        public override void InstallBindings()
        {
            Container.Bind<StateFactory>().AsSingle();
            Container.Bind<Registry>().AsSingle();
            
            Container.Bind<HealthBarCanvas>().FromInstance(_healthBarCanvas).AsSingle();
        }

       
    }
}