using System;
using UnityEngine;

namespace Elementary
{
    public sealed class EventReceiver_String : MonoBehaviour
    {
        public event Action<string> OnEvent;

        public void Call(string value)
        {
            this.OnEvent?.Invoke(value);
        }
    }
}