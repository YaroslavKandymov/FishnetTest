using FishNet.Elementary;
using FishNet.Interfaces;
using UnityEngine;

namespace FishNet.Components
{
    public class MoveComponent : MonoBehaviour, IMoveComponent
    {
        [SerializeField] private Vector3EventReceiver _receiver;
        
        public void Move(Vector3 direction)
        {
            _receiver.Call(direction);
        }
    }
}