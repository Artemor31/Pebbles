using System;
using System.Collections.Generic;

namespace StateMachine
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type,IState> _states;
        private IState _activeState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(SetupState)] = new SetupState(this),
            };
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            _activeState?.Exit();
            _activeState = _states[typeof(TState)];
            _activeState.Enter();
        }
        
        public void EnterAfter<TState>(float delay) where TState : class, IState
        {
            _activeState?.Exit();
            _activeState = _states[typeof(TState)];
            _activeState.Enter();
        }
    }
}