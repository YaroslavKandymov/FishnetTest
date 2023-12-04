using FishNet.Services;
using GameElements.Unity;
using UnityEngine;

namespace FishNet.Game
{
    public class GameStateMachine : MonoBehaviour
    {
        [SerializeField] private MonoGameContext _gameContext;
        [SerializeField] private CharacterService _characterService;

        private void Awake()
        {
            _gameContext.LoadGame();
            _gameContext.InitGame();
            _gameContext.ReadyGame();
        }

        private void OnEnable()
        {
            _characterService.Complete += OnCharacterServiceComplete;
        }

        private void OnDisable()
        {
            _characterService.Complete -= OnCharacterServiceComplete;
        }

        private void OnCharacterServiceComplete()
        {
            _gameContext.StartGame();
        }

        private void OnDestroy()
        {
            _gameContext.FinishGame();
        }
    }
}