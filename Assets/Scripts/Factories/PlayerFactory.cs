using System;
using Entities;
using UnityEngine;

namespace FishNet.Factories
{
    public class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private UnityEntity _entity;

        public event Action<UnityEntity> Spawned; 

        private void Start()
        {
            var entity = Instantiate(_entity);
            
            Spawned?.Invoke(entity);
        }
    }
}