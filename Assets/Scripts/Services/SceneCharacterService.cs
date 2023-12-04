using Entities;
using FishNet.Factories;
using UnityEngine;

namespace FishNet.Services
{
    public class SceneCharacterService : CharacterService
    {
        [SerializeField] private PlayerFactory _factory;

        private void OnEnable()
        {
            _factory.Spawned += Spawned;
        }

        private void OnDisable()
        {
            _factory.Spawned -= Spawned;
        }

        private void Spawned(UnityEntity entity)
        {
            OnSpawned(entity);
        }
    }
}