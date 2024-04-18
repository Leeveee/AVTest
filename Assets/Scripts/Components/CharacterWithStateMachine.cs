namespace Components
{
    public class CharacterWithStateMachine : CharacterBase
    {
        private StateMachine.StateMachine _stateMachine;
        public StateMachine.StateMachine StateMachine => _stateMachine;

        private void Update()
        {
            if (StateMachine != null)
            {
                StateMachine.Tick();
            }
        }

        protected CharacterWithStateMachine Build()
        {
            IsAlive = true;
            StateMachine.Init();
            return this;
        }

        public void SetStateMachine (StateMachine.StateMachine startMachine)
        {
            _stateMachine = startMachine;
        }
    }
}