using System;
using FishNet.Elementary;
using UnityEngine;

namespace FishNet.Mechanics
{
    public class RotateMechanic : MonoBehaviour
    {
        [SerializeField] private Vector3EventReceiver _eventReceiver;
        [SerializeField] private Transform _transform;

        private bool _flipRotation = true;

        private void OnEnable()
        {
            _eventReceiver.Event += OnEvent;
        }

        private void OnDisable()
        {
            _eventReceiver.Event -= OnEvent;
        }

        private void OnEvent(Vector3 direction)
        {
            Rotate(direction.x, direction.z);
        }

        private void Rotate(float horizontal, float vertical)
        {
            float angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
            angle = _flipRotation ? -angle : angle;

            if (Math.Abs(vertical) > Mathf.Epsilon && Math.Abs(horizontal) > Mathf.Epsilon)
                _transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));
        }
    }
}