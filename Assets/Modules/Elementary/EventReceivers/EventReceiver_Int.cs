using System;
using UnityEngine;

namespace Elementary
{
    public sealed class EventReceiver_Int : MonoBehaviour
    {
        public event Action<int> OnEvent;

        public void Call(int value)
        {
            this.OnEvent?.Invoke(value);
        }
    }
}