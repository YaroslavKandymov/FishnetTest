using System;
using System.Collections;
using FishNet.StringFields;
using GameElements;
using UnityEngine;

namespace FishNet.Input
{
    public class KeyInput : MonoBehaviour, IGameStartElement, IGameFinishElement
    {
        private Coroutine _coroutine;
        
        public event Action<Vector3> DirectionChanged; 

        void IGameStartElement.StartGame(IGameContext context)
        {
            _coroutine = StartCoroutine(Move());
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }

        private IEnumerator Move()
        {
            while (true)
            {
                float horizontal = UnityEngine.Input.GetAxis(KeyboardInputFields.Horizontal);
                float vertical = UnityEngine.Input.GetAxis(KeyboardInputFields.Vertical);
                
                DirectionChanged?.Invoke(new Vector3(horizontal, 0, vertical));

                yield return null;
            }
        }
    }
}