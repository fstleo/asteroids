using System;

namespace Game.Core.Entities.Interfaces
{
    public interface IMove
    {
        event Action OnReachTarget;
        void SetSpeed(float speed);
    }
}