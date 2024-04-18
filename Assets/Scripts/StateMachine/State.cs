using Components;

namespace StateMachine
{
  public class State
  {
    private StateMachine _stateMachine;

    public virtual void Init (StateMachine stateMachine)
    {
      _stateMachine = stateMachine;
    }
    
    public virtual void SetDependence (Stickman stickman) {}

    public virtual void Enter()
    {}

    public virtual void Tick()
    {}

    public virtual void Exit()
    {}
  }
}