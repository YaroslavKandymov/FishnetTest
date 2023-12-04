using System;
using System.Collections;
using UnityEngine;

namespace Elementary
{
    [AddComponentMenu("Elementary/Stopwatch")]
    public sealed class StopwatchBehaviour : MonoBehaviour
    {
        public event Action OnStarted;

        public event Action OnTimeChanged;

        public event Action OnCanceled;

        public event Action OnReset;

        public bool IsPlaying { get; private set; }

        public float CurrentTime
        {
            get { return currentTime; }
            set { currentTime = Mathf.Max(value, 0); }
        }

        private float currentTime;

        private Coroutine coroutine;
        
        public void Play()
        {
            if (IsPlaying)
            {
                return;
            }

            IsPlaying = true;
            OnStarted?.Invoke();
            coroutine = StartCoroutine(TimerRoutine());
        }

        public void Stop()
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }

            if (IsPlaying)
            {
                IsPlaying = false;
                OnCanceled?.Invoke();
            }
        }
        
        public void ResetTime()
        {
            currentTime = 0;
            OnReset?.Invoke();
        }

        private IEnumerator TimerRoutine()
        {
            while (true)
            {
                yield return null;
                currentTime += Time.deltaTime;
                OnTimeChanged?.Invoke();
            }
        }
    }
}