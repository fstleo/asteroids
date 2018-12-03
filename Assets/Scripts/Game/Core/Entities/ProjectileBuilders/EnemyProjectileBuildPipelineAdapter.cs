using Game.Core.Interfaces;
using Game.Core.Player.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Core.Entities.ProjectileBuilders
{
    public class EnemyProjectileBuildPipelineAdapter : IBuildPipeline<GameObject>
    {
        private readonly IFactory<int, IBuildPipeline<GameObject>> _pipelineFactory;
        private readonly IScoreSource _playerScore;


        public EnemyProjectileBuildPipelineAdapter(IScoreSource playerScore,
            IFactory<int, IBuildPipeline<GameObject>> pipelineFactory)
        {
            _playerScore = playerScore;
            _pipelineFactory = pipelineFactory;
        }

        public void SetNext(IBuildPipeline<GameObject> pipeline)
        {
        }

        public GameObject Build(GameObject obj)
        {
            return _pipelineFactory.Create(_playerScore.Scores).Build(obj);
        }
    }
}