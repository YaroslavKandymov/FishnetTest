using FishNet.Object;
using Elementary;
using FishNet.Animations;
using FishNet.Elementary;
using FishNet.Other;
using UnityEngine;

namespace FishNet.Mechanics
{
    public class NetworkMoveMechanic : NetworkBehaviour
    {
        [SerializeField] private Vector3EventReceiver _receiver;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private FloatBehaviour _speed;
        [SerializeField] private SoldierAnimationsPlayer _animationsPlayer;

        private SurfaceSlider _surfaceSlider;

        private void Awake()
        {
            _surfaceSlider = new SurfaceSlider();
        }

        private void OnEnable()
        {
            _receiver.Event += OnEvent;
        }

        private void OnDisable()
        {
            _receiver.Event -= OnEvent;
        }

        private void OnEvent(Vector3 direction)
        {
            Move(direction);
        }

        private void Move(Vector3 direction)
        {
            if (!IsOwner)
                return;
            
            Vector3 directionAlongSurface = _surfaceSlider.Project(direction.normalized);
            Vector3 offset = directionAlongSurface * (_speed.Value * Time.deltaTime);

            var nextPosition = _rigidbody.position + offset;

            _rigidbody.MovePosition(nextPosition);
            
            if (direction == Vector3.zero)
            {
                _animationsPlayer.PlayIdleAnimation();
            }
            else
            {
                _animationsPlayer.PlayRunAnimation();
            }
        }
    }
}
