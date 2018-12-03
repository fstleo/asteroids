using Game.Core.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Core.Entities
{
    public class ProjectilesFactory : IFactory<Vector2, Vector2, IProjectile>
    {
        private readonly IBuildPipeline<GameObject> _projectileBuildPipeline;
        private readonly IMemoryPool<GameObject> _projectilesPool;

        public ProjectilesFactory(IMemoryPool<GameObject> projectilesPool,
            IBuildPipeline<GameObject> projectileBuildPipeline)
        {
            _projectilesPool = projectilesPool;
            _projectileBuildPipeline = projectileBuildPipeline;
        }


        public IProjectile Create(Vector2 position, Vector2 target)
        {
            var projectile = _projectileBuildPipeline.Build(_projectilesPool.Spawn()).GetComponent<IProjectile>();
            projectile.Position = position;
            projectile.Target = target;
            return projectile;
        }
    }

    public interface IProjectile
    {
        Vector2 Position { get; set; }
        Vector2 Target { get; set; }
        void Shot();
    }
}