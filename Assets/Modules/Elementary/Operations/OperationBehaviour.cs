using System;
using UnityEngine;

namespace Elementary
{
    public abstract class OperationBehaviour<T> : MonoBehaviour
    {
        public event Action<T> OnOperationStarted;

        public event Action<T> OnOperationCanceled;

        public event Action<T> OnOperationFinished;

        public bool IsStarted { get; private set; }

        public T CurrentOperation { get; private set; }

        public void StartOperation(T operation)
        {
            if (IsStarted)
            {
                Debug.LogWarning("Operation is already started!");
                return;
            }

            IsStarted = true;
            CurrentOperation = operation;
            OnOperationStarted?.Invoke(operation);
        }

        public void FinishOperation()
        {
            if (!IsStarted)
            {
                Debug.LogWarning("Operation is not started!");
                return;
            }

            IsStarted = false;
            var operation = CurrentOperation;
            CurrentOperation = default;

            OnOperationFinished?.Invoke(operation);
        }

        public void CancelOperation()
        {
            if (!IsStarted)
            {
                Debug.LogWarning("Operation is not started!");
                return;
            }

            IsStarted = false;
            var operation = CurrentOperation;
            CurrentOperation = default;

            OnOperationCanceled?.Invoke(operation);
        }
    }
}