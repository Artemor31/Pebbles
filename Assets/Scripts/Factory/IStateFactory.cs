using StateMachine;

namespace Factory
{
    public interface IStateFactory
    {
        IState Create<TState>() where TState : IState;
    }
}