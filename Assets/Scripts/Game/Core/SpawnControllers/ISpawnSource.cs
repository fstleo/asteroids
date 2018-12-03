using System;
using Game.Core.Interfaces;
using UnityEngine;

namespace Game.Core.SpawnControllers
{
    public interface ISpawnSource
    {
        event Action<Vector2, ICommand> OnSpawn;
    }
}