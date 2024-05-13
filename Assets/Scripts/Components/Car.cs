using Core;
using Dreamteck.Splines;
using HealthBar;
using HealthHandler;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Components
{
    public class Car : CharacterBase
    {
        private Registry _registry;
        private HealthBarCanvas _healthBarCanvas;
        private GameManager _gameManager;
        private SplineFollower _splineFollower;
        private CarConfig _carConfig;

        public Vector3 Position => transform.position;

        [Inject]
        protected void Construct (Registry registry, HealthBarCanvas healthBarCanvas, GameManager gameManager, GameConfig gameConfig)
        {
           
            _registry = registry;
            _healthBarCanvas = healthBarCanvas;
            _gameManager = gameManager;
            _carConfig = gameConfig.CarConfig;
        }


        private void Awake()
        {
            IsAlive = true;
            _registry.Car = this;
            _healthBarCanvas.SpawnHealthBar(GetComponent<HealthComponent>());
            _splineFollower = GetComponent<SplineFollower>();
        }

        private void OnEnable()
        {
            _splineFollower.followSpeed = 0;
            _gameManager.ClickToStart += StartMove;
        }

        private void OnDisable()
        {
            _gameManager.ClickToStart -= StartMove;
        }

        private void OnCollisionEnter (Collision collision)
        {
            if (collision.gameObject.TryGetComponent( out Stickman stickman))
            {
                HealthComponent healthComponent =  stickman.GetComponent<HealthComponent>();
                healthComponent.GetDamage(healthComponent.Health);
            }
        }

        public override void Death()
        {
            base.Death();
            _gameManager.Lose();
        }

        public override HealthData HealthData => _carConfig.HealthData;

        private void StartMove()
        {
            _splineFollower.followSpeed = _carConfig.Speed;
        } 
    }
}