using System;
using System.Collections.Generic;
using Entities;

namespace FishNet.Other
{
    public static class PlayersDatabase
    {
        private static readonly Queue<IEntity> _entities;

        public static event Action Added;

        static PlayersDatabase()
        {
            _entities = new Queue<IEntity>();
        }
        
        public static void Add(IEntity entity)
        {
            _entities.Enqueue(entity);
            
            Added?.Invoke();
        }

        public static IEntity GetLast()
        {
            if (_entities.Count <= 0)
                return null;
            
            return _entities.Dequeue();
        }
    }
}