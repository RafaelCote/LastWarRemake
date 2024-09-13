using System;

namespace MrHatProduction.Tools.StateMachine
{
    public class StateMachine<T>
    {
        public event Action StateChanged = null;
        public State<T> CurrentState => _currentState;
        
        private State<T> _currentState = null;
        private T _owner = default;
        
        public void Init(T owner, State<T> startingState)
        {
            _owner = owner;
            _currentState = startingState;
            _currentState.Enter(_owner);
            StateChanged?.Invoke();
        }

        public void Update()
        {
            if (_currentState is UpdatableState<T> updatableState)
                updatableState.Update();
        }
        
        public void ChangeState(State<T> newState)
        {
            _currentState.Exit();
            _currentState = newState;
            _currentState.Enter(_owner);
            StateChanged?.Invoke();
        }
    }
}