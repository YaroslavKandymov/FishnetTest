using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameElements.Unity
{
    [AddComponentMenu("GameElements/Game Сontext")]
    [DisallowMultipleComponent]
    public class MonoGameContext : MonoBehaviour, IGameContext
    {
        public event Action OnLoaded;

        public bool IsAutoRun
        {
            get { return autoRun; }
            set { autoRun = value; }
        }

        [SerializeField]
        private bool autoRun = true;

        private bool isLoaded;

        [Space]
        [SerializeField]
        private List<MonoBehaviour> gameServices = new();

        [Space]
        [SerializeField]
        private List<MonoBehaviour> gameElements = new();

        public event Action OnGameInitialized
        {
            add { gameContext.OnGameInitialized += value; }
            remove { gameContext.OnGameInitialized -= value; }
        }

        public event Action OnGameReady
        {
            add { gameContext.OnGameReady += value; }
            remove { gameContext.OnGameReady -= value; }
        }

        public event Action OnGameStarted
        {
            add { gameContext.OnGameStarted += value; }
            remove { gameContext.OnGameStarted -= value; }
        }

        public event Action OnGamePaused
        {
            add { gameContext.OnGamePaused += value; }
            remove { gameContext.OnGameResumed -= value; }
        }

        public event Action OnGameResumed
        {
            add { gameContext.OnGameResumed += value; }
            remove { gameContext.OnGameResumed -= value; }
        }

        public event Action OnGameFinished
        {
            add { gameContext.OnGameFinished += value; }
            remove { gameContext.OnGameFinished -= value; }
        }

        public GameState State
        {
            get { return gameContext.State; }
        }

        private readonly IGameContext gameContext;

        public MonoGameContext()
        {
            gameContext = new GameContext();
        }

        [ContextMenu("Load Game")]
        public void LoadGame()
        {
            if (isLoaded)
            {
                Debug.LogWarning("Game is already loaded!");
                return;
            }

            LoadServices();
            LoadElements();
            isLoaded = true;
            OnLoaded?.Invoke();
        }
        
        [ContextMenu("Init Game")]
        public void InitGame()
        {
            gameContext.InitGame();
        }

        [ContextMenu("Ready Game")]
        public void ReadyGame()
        {
            gameContext.ReadyGame();
        }

        [ContextMenu("Start Game")]
        public void StartGame()
        {
            gameContext.StartGame();
        }

        [ContextMenu("Pause Game")]
        public void PauseGame()
        {
            gameContext.PauseGame();
        }

        [ContextMenu("Resume Game")]
        public void ResumeGame()
        {
            gameContext.ResumeGame();
        }

        [ContextMenu("Finish Game")]
        public void FinishGame()
        {
            gameContext.FinishGame();
        }

        public void RegisterElement(IGameElement element)
        {
            gameContext.RegisterElement(element);
        }

        public void UnregisterElement(IGameElement element)
        {
            gameContext.UnregisterElement(element);
        }

        public void RegisterService(object service)
        {
            gameContext.RegisterService(service);
        }

        public void UnregisterService(object service)
        {
            gameContext.UnregisterService(service);
        }

        public T GetService<T>()
        {
            return gameContext.GetService<T>();
        }

        public object[] GetAllServices()
        {
            return gameContext.GetAllServices();
        }

        public object GetService(Type type)
        {
            return gameContext.GetService(type);
        }

        public bool TryGetService<T>(out T service)
        {
            return gameContext.TryGetService(out service);
        }

        public bool TryGetService(Type type, out object service)
        {
            return gameContext.TryGetService(type, out service);
        }

        private IEnumerator Start()
        {
            if (autoRun)
            {
                yield return new WaitForEndOfFrame();
                LoadGame();
                InitGame();
                ReadyGame();
                StartGame();
            }
        }

        private void LoadElements()
        {
            for (int i = 0, count = gameElements.Count; i < count; i++)
            {
                var monoElement = gameElements[i];
                if (monoElement is IGameElement gameElement)
                {
                    RegisterElement(gameElement);
                }
            }
        }

        private void LoadServices()
        {
            for (int i = 0, count = gameServices.Count; i < count; i++)
            {
                var monoService = gameServices[i];
                if (monoService != null)
                {
                    RegisterService(monoService);
                }
            }
        }

#if UNITY_EDITOR
        public void Editor_AddElement(MonoBehaviour gameElement)
        {
            gameElements.Add(gameElement);
        }

        public void Editor_AddService(MonoBehaviour gameService)
        {
            gameServices.Add(gameService);
        }

        private void OnValidate()
        {
            EditorValidator.ValidateServices(ref gameServices);
            EditorValidator.ValidateElements(ref gameElements);
        }
#endif
    }
}