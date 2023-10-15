using UFlow.Addon.ECS.Core.Runtime;

namespace UFlow.Addon.EntityStates.Core.Runtime.Systems {
    public abstract class BaseStateDeltaSystem<TStateMachine, TState> : BaseSetIterationCallbackDeltaSystem 
        where TStateMachine : IEcsStateMachine
        where TState : IEcsState {
        protected EntityStateCommandBuffer StateCommandBuffer { get; }

        public BaseStateDeltaSystem(in World world) : base(in world, world.BuildQuery().With<TStateMachine>().With<TState>()) =>
            StateCommandBuffer = new EntityStateCommandBuffer();

        internal override void ExecuteCommandBuffers() {
            base.ExecuteCommandBuffers();
            StateCommandBuffer.ExecuteCommands();
        }
    }
}