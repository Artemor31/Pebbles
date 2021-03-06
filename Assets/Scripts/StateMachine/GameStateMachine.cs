using System;
using System.Collections;
using System.Collections.Generic;
using Bootstrappers;
using Factory;
using UnityEngine;

namespace StateMachine
{
    public class GameStateMachine
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IStateFactory _factory;
        
        private Dictionary<Type,IState> _states;
        private IState _activeState;

        public GameStateMachine(ICoroutineRunner coroutineRunner, IStateFactory factory)
        {
            _coroutineRunner = coroutineRunner;
            _factory = factory;
        }

        public void Init()
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(SetupState)] = _factory.Create<SetupState>(),
                [typeof(PebbleState)] = _factory.Create<PebbleState>(),
                [typeof(SetupValueCardsState)] = _factory.Create<SetupValueCardsState>(),
                [typeof(ValueCardsState)] = _factory.Create<ValueCardsState>(),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            _activeState?.Exit();
            _activeState = _states[typeof(TState)];
            _activeState.Enter();
        }
        
        public void EnterAfterDelay<TState>(float seconds) where TState : class, IState
        {
            _coroutineRunner.RunCoroutine(DelayInvoke(seconds));
            _activeState?.Exit();
            _activeState = _states[typeof(TState)];
            _activeState.Enter();
        }

        private IEnumerator DelayInvoke(float delay)
        {
            yield return new WaitForSeconds(delay);
        }
    }
}