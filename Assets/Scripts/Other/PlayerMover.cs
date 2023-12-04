using FishNet.Input;
using FishNet.Interfaces;
using FishNet.Services;
using GameElements;
using UnityEngine;

namespace FishNet.Other
{
    public class PlayerMover : MonoBehaviour, IGameInitElement, IGameFinishElement
    {
        [SerializeField] private KeyInput _input;

        private IMoveComponent _moveComponent;
        private CharacterService _characterService;

        void IGameInitElement.InitGame(IGameContext context)
        {
            _characterService = context.GetService<CharacterService>();

            _characterService.Complete += OnComplete;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _input.DirectionChanged -= OnDirectionChanged;
        }

        private void OnComplete()
        {
            StartWork();
        }

        private void StartWork()
        {
            _characterService.Complete -= OnComplete;

            _moveComponent = TryGetMoveComponent();

            _input.DirectionChanged += OnDirectionChanged;
        }

        private void OnDirectionChanged(Vector3 direction)
        {
            _moveComponent?.Move(direction);
        }

        private IMoveComponent TryGetMoveComponent()
        {
            return _characterService.GetCharacter()?.Get<IMoveComponent>();
        }
    }
}