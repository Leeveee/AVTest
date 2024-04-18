using Animation;
using Components;
using Core;
using DamageHandler;
using Extensions;
using UnityEngine;
using Zenject;

namespace StateMachine.States.StickmanStates
{
    public class RunState : State
    {
        private const float ROTATION_SPEED = 140;
        private const float MOVE_SPEED = 5;
        private Stickman _stickman;
        private AnimationComponent _animatorComponent;
        private readonly Registry _registry;
        private readonly GameManager _gameManager;

        [Inject]
        private RunState (Registry registry, GameManager gameManager)
        {
            _registry = registry;
            _gameManager = gameManager;
        }

        public override void SetDependence (Stickman stickman)
        {
            _stickman = stickman;
        }

        public override void Init (StateMachine stateMachine)
        {
            base.Init(stateMachine);
            _animatorComponent = _stickman.GetComponent<AnimationComponent>();
        }

        public override void Enter()
        {
            _animatorComponent.ChangeAnimation(AnimatorHash.Run, AnimationComponent.LITTLE_SMOOTH);
        }

        public override void Tick()
        {
            var _currentTarget = _registry.Car;

            if (_currentTarget == null||_gameManager.IsEndGame)
            {
                _stickman.StateMachine.ChangeState<StickmanIdleState>();
                return;
            }

            Move(_currentTarget.Position);

            if (Vector3.Distance(_stickman.transform.position, _currentTarget.Position) < 10f)
            {
                _stickman.StateMachine.ChangeState<StickmanAttackState>();
            }
        }

        private void Move (Vector3 destination)
        {
            Vector3 direction = (destination - _stickman.transform.position).normalized;

            _stickman.transform.position += direction * (MOVE_SPEED * Time.deltaTime);

            if (direction != Vector3.zero)
            {
                Quaternion newRotation = _stickman.transform.rotation.RotateTowardsDirection(direction, ROTATION_SPEED);
                _stickman.transform.rotation = newRotation;
            }
        }
    }
}