using System;
using UnityEngine;

namespace Game.Core.Interfaces
{
    public interface ISpawnInput
    {
        event Action<Vector2, Vector2> OnInput;
    }
}