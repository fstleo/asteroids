using Game.Core.Interfaces;
using Game.Core.SpawnControllers;
using UnityEngine;
using Zenject;

namespace Game.Core.Player
{
    public class PlayerSpawnTracker
    {
        private readonly IMemoryPool<GameObject> _markPool;
        private readonly ISpawnSource _spawnEventsSource;

        public PlayerSpawnTracker(IMemoryPool<GameObject> markPool, ISpawnSource spawnEventsSource)
        {
            _markPool = markPool;
            _spawnEventsSource = spawnEventsSource;
            spawnEventsSource.OnSpawn += OnCommandEnqueue;
        }

        private void OnCommandEnqueue(Vector2 target, ICommand command)
        {
            var mark = _markPool.Spawn();
            mark.transform.position = target;

//        command.OnExecute += _markPool.Despawn(mark);
        }
    }
}