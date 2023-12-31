using System;
using UnityEngine;

namespace Elementary
{
    [AddComponentMenu("Elementary/Float")]
    public sealed class FloatBehaviour : MonoBehaviour
    {
        public event Action<float> OnValueChanged;

        public float Value
        {
            get { return this.value; }
        }
        
        [SerializeField]
        private float value;

        public void Assign(float value)
        {
            this.value = value;
            this.OnValueChanged?.Invoke(value);
        }

        public void Plus(float range)
        {
            var newValue = this.value + range;
            this.Assign(newValue);
        }

        public void Minus(float range)
        {
            var newValue = this.value - range;
            this.Assign(newValue);
        }

        public void Multiply(float multiplier)
        {
            var newValue = this.value * multiplier;
            this.Assign(newValue);
        }
        
        public void Divide(float divider)
        {
            var newValue = this.value / divider;
            this.Assign(newValue);
        }
    }
}