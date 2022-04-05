using System;
using System.Collections;
using System.Collections.Generic;
using Bootstrappers;
using UnityEngine;

namespace StateMachine
{
    public class GameStateMachine
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly Dictionary<Type,IState> _states;
        private IState _activeState;

        
        public GameStateMachine(GameplayContext context, ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            
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