using Game.Core.Entities.ProjectileBuilders;
using Game.Core.Player.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Core.Entities
{
    public class ScoreVault : MonoBehaviour, IScoreVault
    {
        private int _score;
        private IScoreGetter _scoreGetter;

        public void SetScore(int score)
        {
            _score = score;
        }

        [Inject]
        public void Construct(IScoreGetter scoreGetter)
        {
            _scoreGetter = scoreGetter;
        }

        private void GiveScoreToPlayer()
        {
            _scoreGetter.AddScore(_score);
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<PlayerBase>() == null) GiveScoreToPlayer();
        }
    }
}