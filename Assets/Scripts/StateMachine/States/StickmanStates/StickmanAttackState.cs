using Animation;
using Components;
using Core;
using HealthHandler;
using UnityEngine;
using Zenject;

namespace StateMachine.States.StickmanStates
{
    public class StickmanAttackState : State
    {
        private const float MIN_DISTANCE = 20f;
        
        private Stickman _stickman;
        private AnimationComponent _animatorComponent;
        private AnimatorEventHolder _animatorEventHolder;
        private readonly Registry _registry;

        [Inject]
        private StickmanAttackState (Registry registry)
        {
            _registry = registry;
        }
      
        public override void SetDependence (Stickman stickman)
        {
            _stickman = stickman;
        }

        public override void Init (StateMachine stateMachine)
        {
            base.Init(stateMachine);
            _animatorComponent = _stickman.GetComponent<AnimationComponent>();
            _animatorEventHolder = _stickman.GetComponentInChildren<AnimatorEventHolder>();
        }

        public override void Enter()
        {
            _animatorEventHolder.TakeDamage += OnTakeDamage;
            _animatorComponent.ChangeAnimation(AnimatorHash.Attack, AnimationComponent.LITTLE_SMOOTH);
        }

        public override void Tick()
        {
            if (_registry.Car==null|| Vector3.Distance(_stickman.transform.position,  _registry.Car.Position) > MIN_DISTANCE || _registry.Car.IsAlive==false)
            {
                _stickman.StateMachine.ChangeState<StickmanIdleState>();
            }
        }

        public override void Exit()
        {
            _animatorEventHolder.TakeDamage -= OnTakeDamage;
        }

        private void OnTakeDamage()
        {
            _registry.Car.GetComponent<HealthComponent>().GetDamage(_stickman.Damage);
        }
    }
}