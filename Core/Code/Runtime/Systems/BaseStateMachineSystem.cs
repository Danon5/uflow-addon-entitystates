using UFlow.Addon.ECS.Core.Runtime;

namespace UFlow.Addon.EntityStates.Core.Runtime.Systems {
    public abstract class BaseStateMachineSystem<TStateMachine> : BaseSetCallbackSystem 
        where TStateMachine : IEcsStateMachine {
        protected BaseStateMachineSystem(in World world) : base(in world, world.BuildQuery().With<TStateMachine>()) { }

        protected sealed override void EntityAdded(World world, in Entity entity) {
            var stateMachine = entity.Get<TStateMachine>().Value;
            stateMachine.Initialize(entity);
            InitializeStateMachine(stateMachine);
        }

        protected sealed override void EntityRemoved(World world, in Entity entity) { }

        protected virtual void InitializeStateMachine(in EntityStateMachine stateMachine) { }
    }
}