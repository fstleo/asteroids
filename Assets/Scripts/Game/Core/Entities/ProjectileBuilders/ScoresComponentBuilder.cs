using Game.Core.Common;
using UnityEngine;

namespace Game.Core.Entities.ProjectileBuilders
{
    public class ScoresComponentBuilder : GameObjectBuildPipeline
    {
        private readonly int _score;

        public ScoresComponentBuilder(int score)
        {
            _score = score;
        }

        protected override void ProcessBuild(GameObject gameObject)
        {
            gameObject.GetComponent<IScoreVault>().SetScore(_score);
        }
    }

    public interface IScoreVault
    {
        void SetScore(int score);
    }
}