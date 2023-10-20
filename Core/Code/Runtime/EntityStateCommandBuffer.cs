using UFlow.Addon.ECS.Core.Runtime;

namespace UFlow.Addon.EntityStates.Core.Runtime {
    public sealed class EntityStateCommandBuffer : BaseCommandBuffer {
        public void ReturnToDefaultState(in EntityStateMachine stateMachine) =>
            EnqueueCommand(stateMachine.Entity, new ReturnToDefaultStateCommand(stateMachine));

        public void SetState<T>(in EntityStateMachine stateMachine, in T newState) where T : IEcsState =>
            EnqueueCommand(stateMachine.Entity, new SetStateCommand<T>(stateMachine, newState));
    }
}