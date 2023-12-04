using System;
using UnityEngine;

namespace Elementary
{
    [AddComponentMenu("Elementary/Multi Event Receiver «Base»")]
    public sealed class MultiEventReceiver_Base : MultiEventReceiver
    {
        public override event Action OnEventReceived;

        public override event Action<bool> OnBoolReceived;

        public override event Action<int> OnIntReceived;

        public override event Action<float> OnFloatReceived;

        public override event Action<string> OnStringReceived;
        
        public override event Action<object> OnObjectReceived;

        public void ReceiveString(string message) 
        {
            this.OnStringReceived?.Invoke(message);
        }

        public void ReceiveBool(bool message)
        {
            this.OnBoolReceived?.Invoke(message);
        }

        public void ReceiveInt(int message)
        {
            this.OnIntReceived?.Invoke(message);
        }

        public void ReceiveFloat(float message)
        {
            this.OnFloatReceived?.Invoke(message);
        }

        public void ReceiveObject(object obj)
        {
            this.OnObjectReceived?.Invoke(obj);
        }

        public void ReceiveEvent()
        {
            this.OnEventReceived?.Invoke();
        }
    }
}