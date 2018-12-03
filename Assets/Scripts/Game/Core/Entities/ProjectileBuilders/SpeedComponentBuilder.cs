using Game.Core.Common;
using Game.Core.Entities.Interfaces;
using UnityEngine;

namespace Game.Core.Entities.ProjectileBuilders
{
    public class SpeedComponentBuilder : GameObjectBuildPipeline
    {
        private readonly float _speed;

        public SpeedComponentBuilder(float speed)
        {
            _speed = speed;
        }

        protected override void ProcessBuild(GameObject gameObject)
        {
            gameObject.GetComponent<IMove>().SetSpeed(_speed);
        }
    }
}