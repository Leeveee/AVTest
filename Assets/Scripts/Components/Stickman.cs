using System.Collections.Generic;
using DamageHandler;
using HealthBar;
using HealthHandler;
using StateMachine;
using StateMachine.States.StickmanStates;
using UnityEngine;
using Zenject;

namespace Components
{
    public class Stickman : CharacterWithStateMachine, IDamageDealer
    {
        [SerializeField]
        private int _damage;
        
        private StateFactory _stateFactory;
        private HealthBarCanvas _healthBarCanvas;
        public int Damage { get => _damage; }

        [Inject]
        public void Construct (StateFactory stateFactory,HealthBarCanvas healthBarCanvas)
        {
            _stateFactory = stateFactory;
            _healthBarCanvas = healthBarCanvas;
        }

        private void Awake()
        {
            BuildStickman();
        }

        private void BuildStickman()
        {
            List<State> states = new List<State>
            {
                _stateFactory.CreatState<StickmanIdleState>(),
                _stateFactory.CreatState<RunState>(),
                _stateFactory.CreatState<StickmanAttackState>(),
            };

            foreach (State state in states)
            {
                state.SetDependence(this);
            }


            SetStateMachine(new StateMachine.StateMachine(states));
   
            Build().StateMachine.StartMachine();
            _healthBarCanvas.SpawnHealthBar(GetComponent<HealthComponent>());
        }
    }
}