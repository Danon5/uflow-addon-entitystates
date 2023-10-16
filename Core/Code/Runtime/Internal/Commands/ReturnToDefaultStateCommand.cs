namespace UFlow.Addon.EntityStates.Core.Runtime {
    internal sealed class ReturnToDefaultStateCommand : IEcsStateCommand {
        public void Execute(in EntityStateMachine stateMachine) => stateMachine.ReturnToDefaultState();
    }
}