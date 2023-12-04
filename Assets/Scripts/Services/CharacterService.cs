using System;
using Entities;
using UnityEngine;

namespace FishNet.Services
{
    public abstract class CharacterService : MonoBehaviour
    {
        private IEntity _entity;

        public event Action Complete;

        public IEntity GetCharacter()
        {
            return _entity;
        }

        protected void OnSpawned(IEntity entity)
        {
            _entity = entity;

            Complete?.Invoke();
        }
    }
}