using System;
using UnityEngine;

namespace Elementary
{
    public sealed class EventReceiver : MonoBehaviour
    {
        public event Action OnEvent;

        public void Call()
        {
            this.OnEvent?.Invoke();
        }
    }
}