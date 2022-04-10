using StateMachine;
using Zenject;

namespace Factory
{
    class StateFactory : IStateFactory
    {
        private readonly DiContainer _container;

        public StateFactory(DiContainer container) => 
            _container = container;

        public IState Get<TState>() where TState : IState => 
            _container.Resolve<TState>();
    }
}