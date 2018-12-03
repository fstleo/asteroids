using Game.Core.Interfaces;
using UnityEngine;

namespace Game.Core.Common
{
    public abstract class GameObjectBuildPipeline : IBuildPipeline<GameObject>
    {
        private IBuildPipeline<GameObject> _next;

        public void SetNext(IBuildPipeline<GameObject> pipeline)
        {
            _next = pipeline;
        }

        public GameObject Build(GameObject obj)
        {
            ProcessBuild(obj);
            return _next == null ? obj : _next.Build(obj);
        }

        protected abstract void ProcessBuild(GameObject gameObject);
    }
}