using Entities;
using UnityEngine;

namespace FishNet.Other
{
    public class EntityListAdder : MonoBehaviour
    {
        [SerializeField] private UnityEntity _entity;
        
        private void Start()
        {
            PlayersDatabase.Add(_entity);
        }
    }
}