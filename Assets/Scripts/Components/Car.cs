using System;
using Core;
using HealthBar;
using HealthHandler;
using UnityEngine;
using Zenject;

namespace Components
{
    public class Car : CharacterBase
    {
        private Registry _registry;
        private HealthBarCanvas _healthBarCanvas;

        public Vector3 Position
        {
            get => transform.position;
        }
        

        [Inject]
        private void Construct (Registry registry, HealthBarCanvas healthBarCanvas)
        {
            _registry = registry;
            _healthBarCanvas = healthBarCanvas;
        }
        private void Awake()
        {
            IsAlive = true;
            _registry.Car = this;
            _healthBarCanvas.SpawnHealthBar(GetComponent<HealthComponent>());
        }

        private void OnCollisionEnter (Collision collision)
        {
            if (collision.gameObject.TryGetComponent( out Stickman stickman))
            {
               HealthComponent healthComponent =  stickman.GetComponent<HealthComponent>();
               healthComponent.GetDamage(healthComponent.Health);
            }
        }
    }
}