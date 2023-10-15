using System;
using System.Runtime.CompilerServices;
using Sirenix.OdinInspector;
using UFlow.Addon.ECS.Core.Runtime;
using UnityEngine;

namespace UFlow.Addon.EntityStates.Core.Runtime {
    [Serializable]
    [HideLabel]
    public sealed class EntityStateMachine {
        private Entity m_entity;
        private IEcsState m_defaultState;
        private Type m_defaultStateType;
        private Type m_currentStateType;
        
        [field: SerializeReference] internal IEcsState DefaultState { get; private set; }

        public void Initialize(in Entity entity) {
            m_entity = entity;
            m_defaultState = DefaultState;
            m_defaultStateType = m_defaultState?.GetType();
            ReturnToDefaultState();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReturnToDefaultState() {
            if (m_currentStateType != null)
                m_entity.TryRemoveRaw(m_currentStateType);
            m_entity.SetRaw(m_defaultState);
            m_currentStateType = m_defaultStateType;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetState<T>(in T newState) where T : IEcsState {
            if (m_currentStateType != null)
                m_entity.TryRemoveRaw(m_currentStateType);
            m_entity.Set(newState);
            m_currentStateType = typeof(T);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Type GetCurrentStateType() => m_currentStateType;
    }
}