using Animation;
using Components;
using Core;
using UnityEngine;
using Zenject;

namespace StateMachine.States.StickmanStates
{
    public class StickmanIdleState : State
    {
        private Stickman _stickman;
        private AnimationComponent _animatorComponent;
        private readonly Registry _registry;

        [Inject]
        private StickmanIdleState (Registry registry)
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
        }

        public override void Enter()
        {
            _animatorComponent.ChangeAnimation(AnimatorHash.Idle, AnimationComponent.NONE);
        }

        public override void Tick()
        {
            var _currentTarget = _registry.Car;

            if (_currentTarget == null)
            {
                return;
            }

            if (Vector3.Distance(_stickman.transform.position, _currentTarget.transform.position) < 40f)
            {
                _stickman.StateMachine.ChangeState<RunState>();
            }
        }
    }
}