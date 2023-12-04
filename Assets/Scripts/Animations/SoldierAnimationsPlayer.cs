using FishNet.StringFields;
using UnityEngine;

namespace FishNet.Animations
{
    public class SoldierAnimationsPlayer : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void PlayIdleAnimation()
        {
            _animator.SetFloat(SoldierAnimationsController.Params.Speed, 0);
        }

        public void PlayRunAnimation()
        {
            _animator.SetFloat(SoldierAnimationsController.Params.Speed, 1);
        }
    }
}