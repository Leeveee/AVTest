namespace Components
{
    public abstract class CharacterWithStateMachine : CharacterBase
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

        protected void SetStateMachine (StateMachine.StateMachine startMachine)
        {
            _stateMachine = startMachine;
        }
    }
}