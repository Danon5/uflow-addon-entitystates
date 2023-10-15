using UFlow.Addon.ECS.Core.Runtime;

namespace UFlow.Addon.EntityStates.Core.Runtime {
    internal sealed class SetStateCommand<T> : IEntityStateCommand
        where T : IEcsComponent, IEcsState {
        private readonly T m_newState;

        public SetStateCommand(in T newState) => m_newState = newState;

        public void Execute(in EntityStateMachine stateMachine) => stateMachine.SetState(m_newState);
    }
}