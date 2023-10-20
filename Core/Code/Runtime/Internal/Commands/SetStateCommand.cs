using UFlow.Addon.ECS.Core.Runtime;

namespace UFlow.Addon.EntityStates.Core.Runtime {
    internal readonly struct SetStateCommand<T> : IEcsCommand where T : IEcsState {
        private readonly EntityStateMachine m_stateMachine;
        private readonly T m_newState;

        public SetStateCommand(in EntityStateMachine stateMachine, in T newState) {
            m_stateMachine = stateMachine;
            m_newState = newState;
        }

        public void Execute(in Entity entity) => m_stateMachine.SetState(m_newState);
    }
}