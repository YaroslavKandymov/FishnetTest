using System;
using UnityEngine;

namespace FishNet.Elementary
{
    public class Vector3EventReceiver : MonoBehaviour
    {
        public event Action<Vector3> Event;

        public void Call(Vector3 value)
        {
            Event?.Invoke(value);
        }
    }
}