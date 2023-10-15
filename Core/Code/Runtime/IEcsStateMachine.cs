using UFlow.Addon.ECS.Core.Runtime;

namespace UFlow.Addon.EntityStates.Core.Runtime {
    public interface IEcsStateMachine : IEcsComponent {
        EntityStateMachine Value { get; }
    }
}