using UFlow.Addon.ECS.Core.Runtime;

namespace UFlow.Addon.EntityStates.Core.Runtime.Systems {
    public abstract class BaseGlobalStateSystem<TState> : BaseSetIterationCallbackSystem
        where TState : IEcsState {
        protected EntityStateCommandBuffer StateCommandBuffer { get; }

        public BaseGlobalStateSystem(in World world) : base(in world, world.BuildQuery().With<TState>()) =>
            StateCommandBuffer = new EntityStateCommandBuffer();

        internal override void ExecuteCommandBuffers() {
            base.ExecuteCommandBuffers();
            StateCommandBuffer.ExecuteCommands();
        }
    }
}