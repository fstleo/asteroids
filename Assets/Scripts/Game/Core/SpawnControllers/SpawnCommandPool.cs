using System.Collections.Generic;
using Game.Core.Commands;
using Game.Core.Entities;
using Game.Core.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Core.SpawnControllers
{
    public class SpawnCommandPool : IFactory<IProjectile, ICommand>
    {
        private readonly Queue<ShotProjectileCommand> _commandsQueue;
        private readonly IMemoryPool<GameObject> _projectilePool;

        protected SpawnCommandPool(int size)
        {
            _commandsQueue = new Queue<ShotProjectileCommand>(size);
            for (var i = 0; i < size; i++) CreateCommand();
        }

        public ICommand Create(IProjectile method)
        {
            if (_commandsQueue.Count == 0) CreateCommand();
            var command = _commandsQueue.Dequeue();
            command.Projectile = method;
            return command;
        }

        private void CreateCommand()
        {
            var cmd = new ShotProjectileCommand();
            cmd.OnExecute += () => _commandsQueue.Enqueue(cmd);
            _commandsQueue.Enqueue(cmd);
        }
    }
}