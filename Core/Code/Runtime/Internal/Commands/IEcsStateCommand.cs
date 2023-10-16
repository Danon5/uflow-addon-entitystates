namespace UFlow.Addon.EntityStates.Core.Runtime {
    internal interface IEcsStateCommand {
        void Execute(in EntityStateMachine stateMachine);
    }
}