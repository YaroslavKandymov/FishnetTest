using System;
using UnityEngine;

namespace Elementary
{
    [AddComponentMenu("Elementary/Int")]
    public sealed class IntBehaviour : MonoBehaviour
    {
        public event Action<int> OnValueChanged;

        public int Value
        {
            get { return this.value; }
        }
        
        [SerializeField]
        private int value;

        public void Assign(int value)
        {
            this.value = value;
            this.OnValueChanged?.Invoke(value);
        }

        public void Plus(int range)
        {
            var newValue = this.value + range;
            this.Assign(newValue);
        }

        public void Minus(int range)
        {
            var newValue = this.value - range;
            this.Assign(newValue);
        }

        public void Multiply(int multiplier)
        {
            var newValue = this.value * multiplier;
            this.Assign(newValue);
        }

        public void Divide(int divider)
        {
            var newValue = this.value / divider;
            this.Assign(newValue);
        }
    }
}