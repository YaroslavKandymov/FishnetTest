using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace Elementary
{
    [Serializable]
    public sealed class IntAdapter
    {
        public int Value
        {
            get { return this.GetValue(); }
        }

        [SerializeField]
        private Mode mode;

        [SerializeField]
        private int baseValue;

        [OptionalField]
        [SerializeField]
        private IntBehaviour monoValue;

        [OptionalField]
        [SerializeField]
        private ScriptableInt scriptableValue;

        private int GetValue()
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