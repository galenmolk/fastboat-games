using System;
using UnityEngine;

namespace DC.FSM
{
    public abstract class FiniteStateMachine : MonoBehaviour
    {
        private State currentState;

        private void Start()
        {
            ChangeState(GetDefaultState());
        }

        protected abstract State GetDefaultState();

        public void ChangeState(State state)
        {
            currentState?.Exit();
            currentState = state;
            currentState.Enter();
        }
        
        private void Update()
        {
            currentState.Tick();
        }
    }
}
