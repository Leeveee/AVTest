using System.Collections.Generic;
using DamageHandler;
using HealthBar;
using HealthHandler;
using ScriptableObjects;
using StateMachine;
using StateMachine.States.StickmanStates;
using Zenject;

namespace Components
{
    public class Stickman : CharacterWithStateMachine, IDamageDealer
    {

        private StateFactory _stateFactory;
        private HealthBarCanvas _healthBarCanvas;
        private StickmanConfig _stickmanConfig;
        public int Damage => _stickmanConfig.Damage;

        [Inject]
        public void Construct (StateFactory stateFactory,HealthBarCanvas healthBarCanvas, GameConfig gameConfig)
        {
            _stateFactory = stateFactory;
            _healthBarCanvas = healthBarCanvas;
            _stickmanConfig = gameConfig.StickmanConfig;
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

        public override HealthData HealthData => _stickmanConfig.HealthData;
    }
}