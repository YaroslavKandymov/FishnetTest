using System;
using FishNet.Interfaces;
using UnityEngine;

namespace FishNet.Physics
{
    public class PhysicsTrigger : MonoBehaviour
    {
        public event Action Entered;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IPhysicsModel _))
            {
                Entered?.Invoke();
            }
        }
    }
}