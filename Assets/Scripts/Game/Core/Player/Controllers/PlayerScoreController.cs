using System;
using Game.Core.Player.Interfaces;
using UnityEngine;

namespace Game.Core.Player.Controllers
{
    public class PlayerScoreController : IScoreSource, IScoreGetter
    {
        private const string ScoreKey = "Score";

        private int _scores;

        public void AddScore(int score)
        {
            Scores += score;
        }

        public int TopScores
        {
            get { return PlayerPrefs.GetInt(ScoreKey, 0); }
            private set { PlayerPrefs.SetInt(ScoreKey, value); }
        }

        public event Action<int> OnScoreChange;

        public int Scores
        {
            get { return _scores; }
            private set
            {
                _scores = value;
                if (_scores > TopScores) TopScores = _scores;
                OnScoreChange?.Invoke(_scores);
            }
        }
    }
}