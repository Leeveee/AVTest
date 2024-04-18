using Zenject;

namespace StateMachine
{
  public class StateFactory
  {
    private readonly DiContainer _diContainer;

    [Inject]
    public StateFactory (DiContainer diContainer)
    {
      _diContainer = diContainer;
    }

    public T CreatState<T>() where T : State
    {
      T component = _diContainer.Instantiate<T>();

      return component;
    }
  }
}