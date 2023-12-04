using System;
using UnityEngine;

namespace Elementary
{
    public sealed class ActivationBehaviour : MonoBehaviour
    {
        public event Action OnActivate;

        public event Action OnDeactivate;

        public event Action<bool> OnActive;

        public bool IsActive
        {
            get { return this.isActive; }
        }

        [Space]
        [SerializeField]
        private bool isActive = true;

        public void Activate()
        {
            this.isActive = true;
            this.OnActivate?.Invoke();
        }

        public void Deactivate()
        {
            this.isActive = false;
            this.OnDeactivate?.Invoke();
        }

        public void SetActive(bool isActive)
        {
            if (isActive)
            {
                this.SetActive();
            }
            else
            {
                this.SetInactive();
            }
        }

        public void SetActive()
        {
            this.isActive = true;
            this.OnActive?.Invoke(true);
        }

        public void SetInactive()
        {
            this.isActive = false;
            this.OnActive?.Invoke(false);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            this.SetActive(this.isActive);
        }
#endif
    }
}