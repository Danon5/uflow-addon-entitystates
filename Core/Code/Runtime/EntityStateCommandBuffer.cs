using System.Collections.Generic;

namespace UFlow.Addon.EntityStates.Core.Runtime {
    public sealed class EntityStateCommandBuffer {
        private readonly Queue<BufferedStateCommand> m_buffer = new();

        public void ReturnToDefaultState(in EntityStateMachine stateMachine) => 
            m_buffer.Enqueue(new BufferedStateCommand(stateMachine, new ReturnToDefaultStateCommand()));
        
        public void SetState<T>(in EntityStateMachine stateMachine, in T newState) where T : IEcsState => 
            m_buffer.Enqueue(new BufferedStateCommand(stateMachine, new SetStateCommand<T>(newState)));

        public void ExecuteCommands() {
            while (m_buffer.TryDequeue(out var command)) 
                command.Execute();
        }

        private readonly struct BufferedStateCommand {
            public readonly EntityStateMachine stateMachine;
            public readonly IEcsStateCommand command;

            public BufferedStateCommand(in EntityStateMachine stateMachine, in IEcsStateCommand command) {
                this.stateMachine = stateMachine;
                this.command = command;
            }

            public void Execute() => command.Execute(stateMachine);
        }
    }
}