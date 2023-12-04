using Entities;
using FishNet.Object;
using FishNet.Other;
using UnityEngine;

namespace FishNet.Services
{
    public class NetworkCharacterService : CharacterService
    {
        [SerializeField] private Component.Spawning.PlayerSpawner _spawner;

        private void OnEnable()
        {
            _spawner.OnSpawned += Spawned;

            PlayersDatabase.Added += OnAdded;
        }

        private void OnDisable()
        {
            _spawner.OnSpawned -= Spawned;
            PlayersDatabase.Added -= OnAdded;
        }

        private void OnAdded()
        {
            var entity = PlayersDatabase.GetLast();

            OnSpawned(entity);
        }

        private void Spawned(NetworkObject networkObject)
        {
            var entity = networkObject.GetComponent<IEntity>();

            OnSpawned(entity);
        }
    }
}