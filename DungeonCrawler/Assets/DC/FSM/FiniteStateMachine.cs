using UnityEngine;

namespace DC.FSM
{
    public abstract class FiniteStateMachine : MonoBehaviour
    {
        private State currentState;

        public void ChangeState(State state)
        {
            currentState?.Exit();
            currentState = state;
            currentState.Enter(this);
        }
        
        private void Update()
        {
            currentState.Tick();
        }
    }
}
