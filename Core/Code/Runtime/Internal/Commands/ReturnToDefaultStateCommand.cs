namespace UFlow.Addon.EntityStates.Core.Runtime {
    internal sealed class ReturnToDefaultStateCommand : IEntityStateCommand {
        public void Execute(in EntityStateMachine stateMachine) => stateMachine.ReturnToDefaultState();
    }
}