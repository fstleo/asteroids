using System;

namespace Game.Core.Player.Interfaces
{
    public interface IScoreSource
    {
        int TopScores { get; }
        int Scores { get; }
        event Action<int> OnScoreChange;
    }
}