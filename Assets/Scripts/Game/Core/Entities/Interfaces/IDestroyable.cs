using System;

namespace Game.Core.Entities.Interfaces
{
    public interface IDestroyable
    {
        event Action OnDestroy;
        void Destroy();
    }
}