namespace UFlow.Addon.EntityStates.Core.Runtime {
    internal interface IEntityStateCommand {
        void Execute(in EntityStateMachine stateMachine);
    }
}