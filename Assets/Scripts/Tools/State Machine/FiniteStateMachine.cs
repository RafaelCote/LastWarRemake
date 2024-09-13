using System.Collections.Generic;
using UnityEngine;

namespace MrHatProduction.Tools.StateMachine
{
    public class FiniteStateMachine<T>
    {
        #region Private Classes

        private class Transition
        {
            private State<T> _from;
            private State<T> _to;

            public State<T> To => _to;
            public State<T> From => _from;
        
            public Transition(State<T> from, State<T> to)
            {
                _from = from;
                _to = to;
            }
        }

        #endregion

        private List<Transition> _transitions = null;
        private StateMachine<T> _stateMachine = null;

        public FiniteStateMachine()
        {
            _stateMachine = new StateMachine<T>();
            _transitions = new List<Transition>();
        }

        public void Init(T owner, State<T> startingState)
        {
            _stateMachine.Init(owner, startingState);
        }

        public void Update()
        {
            _stateMachine.Update();
        }

        public void AddTransition(State<T> from, State<T> to)
        {
            var newTransition = new Transition(from, to);
            _transitions.Add(newTransition);
        }

        public bool TryChangeState(State<T> to)
        {
            var transitions = _transitions.FindAll((transition => transition.From == _stateMachine.CurrentState));
            foreach (var transition in transitions)
            {
                if (transition.To.GetType() == to.GetType())
                {
                    _stateMachine.ChangeState(transition.To);
                    return true;
                }
            }

            Debug.LogError($"Current State ({_stateMachine.CurrentState.GetType().Name}) has not transition to {to.GetType().Name} state.");
            return false;
        }
    }
}