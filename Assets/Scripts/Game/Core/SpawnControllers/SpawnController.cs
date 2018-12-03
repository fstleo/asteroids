using System;
using Game.Core.Entities;
using Game.Core.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Core.SpawnControllers
{
    public class SpawnController 
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IFactory<IProjectile, ICommand> _commandFactory;
        private readonly IFactory<Vector2, Vector2, IProjectile> _projectilesFactory;

        public SpawnController(ISpawnInput spawnInput, IFactory<IProjectile, ICommand> commandFactory,
            ICommandExecutor commandExecutor, IFactory<Vector2, Vector2, IProjectile> projectilesFactory)
        {
            spawnInput.OnInput += Spawn;
            _commandFactory = commandFactory;
            _commandExecutor = commandExecutor;
            _projectilesFactory = projectilesFactory;
        }

        private void Spawn(Vector2 origin, Vector2 target)
        {
            var command = _commandFactory.Create(_projectilesFactory.Create(origin, target));
            _commandExecutor.Execute(command);
        }
    }
}