using System;
using UnityEngine;

namespace Elementary
{
    public sealed class EventReceiver_Float : MonoBehaviour
    {
        public event Action<float> OnEvent;

        public void Call(float value)
        {
            this.OnEvent?.Invoke(value);
        }
    }
}