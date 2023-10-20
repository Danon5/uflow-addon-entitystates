using UFlow.Addon.ECS.Core.Runtime;

namespace UFlow.Addon.EntityStates.Core.Runtime {
    internal readonly struct ReturnToDefaultStateCommand : IEcsCommand {
        private readonly EntityStateMachine m_stateMachine;

        public ReturnToDefaultStateCommand(in EntityStateMachine stateMachine) => m_stateMachine = stateMachine;

        public void Execute(in Entity entity) => m_stateMachine.ReturnToDefaultState();
    }
}