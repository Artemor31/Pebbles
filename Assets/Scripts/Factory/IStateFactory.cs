using StateMachine;

namespace Factory
{
    public interface IStateFactory
    {
        IState Get<TState>() where TState : IState;
    }
}