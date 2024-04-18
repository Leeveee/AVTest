using System;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class StateMachine
    {
        private readonly Dictionary<Type, State> _stateMap = new Dictionary<Type, State>();
        private readonly State _defaultState;

        private State currentSate;

        public StateMachine (List<State> states)
        {
            _defaultState = states[0];

            _stateMap.Clear();

            foreach (State state in states)
            {
                Type type = state.GetType();
                _stateMap.Add(type, state);
            }
        }

        public void Init()
        {
            foreach (State state in _stateMap.Values)
            {
                state.Init(this);
            }
        }

        public void StartMachine()
        {
            ChangeState(_defaultState);
        }

        public void ChangeState<T>() where T : State
        {
            Type type = typeof(T);

            if (_stateMap.TryGetValue(type, out var state))
            {
                ChangeState(state);
            }
            else
            {
                Debug.Log($"{type} doesn't contains in StateMachine!");
            }
        }

        public void Tick()
        {
            currentSate?.Tick();
        }

        private void ChangeState (State state)
        {
            currentSate?.Exit();

            currentSate = state;
            currentSate.Enter();
        }
    }
}