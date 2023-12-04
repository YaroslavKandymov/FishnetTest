using System;
using UnityEngine;

namespace Elementary
{
    public sealed class EventReceiver_Bundle : MonoBehaviour
    {
        public event Action<Bundle> OnEvent;

        public void Call(Bundle bundle)
        {
            this.OnEvent?.Invoke(bundle);
        }
    }
}