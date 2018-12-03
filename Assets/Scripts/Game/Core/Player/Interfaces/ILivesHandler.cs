using System;

namespace Game.Core.Player.Interfaces
{
    public interface ILivesHandler
    {
        int LiveCount { get; }
        event Action OnDie;
        event Action<int> OnLiveAmountChange;
    }
}