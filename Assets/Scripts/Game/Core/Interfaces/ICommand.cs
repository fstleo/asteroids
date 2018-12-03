using System;

namespace Game.Core.Interfaces
{
    public interface ICommand
    {
        event Action OnExecute;
        void Execute();
    }
}