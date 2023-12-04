using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace Elementary
{
    [Serializable]
    public sealed class FloatAdapter
    {
        public float Value
        {
            get { return this.GetValue(); }
        }

        [SerializeField]
        private Mode mode;

        [SerializeField]
        private float baseValue;

        [OptionalField]
        [SerializeField]
        private FloatBehaviour monoValue;

        [OptionalField]
        [SerializeField]
        private ScriptableFloat scriptableValue;

        private float GetValue()
        {
            return this.mode switch
            {
                Mode.BASE => this.baseValue,
                Mode.MONO_BEHAVIOUR => this.monoValue.Value,
                Mode.SCRIPTABLE_OBJECT => this.scriptableValue.value,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private enum Mode
        {
            BASE = 0,
            MONO_BEHAVIOUR = 1,
            SCRIPTABLE_OBJECT = 2
        }
    }
}