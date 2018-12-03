using Game.Core.Common;
using Game.Core.Entities;
using Game.Core.Entities.ProjectileBuilders;
using Game.Core.Interfaces;
using Game.Core.SpawnControllers;
using Game.Core.SpawnControllers.Implementation;
using Game.Settings;
using UnityEngine;
using Zenject;

namespace Game.Installers.GameProcess
{
    public class EnemySpawnerInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<SpawnController>().AsSingle();
            Container.BindInterfacesTo<RandomInput>().AsSingle();
            Container.Bind<EnemySettings>().FromResource("Settings/EnemySettings").AsSingle();


            var enemySettings = Container.Resolve<EnemySettings>();

            Container.Bind<float>().FromInstance(enemySettings.Cooldown);

            ChainKeeper<IBuildPipeline<GameObject>> keeper = null;
            for (var index = 0; index < enemySettings.LevelsSettings.Length; index++)
            {
                var setting = enemySettings.LevelsSettings[index];
                IBuildPipeline<GameObject> projectilePipeline = new ScoresComponentBuilder(setting.ScoreForKill);
                projectilePipeline.SetNext(new SpeedComponentBuilder(setting.ProjectileSpeed));
                keeper = new ChainKeeper<IBuildPipeline<GameObject>>(setting.StartFromScore, projectilePipeline,
                    keeper);
            }

            Container.Bind<IFactory<int, IBuildPipeline<GameObject>>>().FromInstance(keeper).AsSingle();

            Container.Bind<IBuildPipeline<GameObject>>().To<EnemyProjectileBuildPipelineAdapter>().AsSingle();
            Container.Bind<IFactory<Vector2, Vector2, IProjectile>>().To<ProjectilesFactory>().AsSingle();

            Container.Bind<GameObject>().FromInstance(enemySettings.Prefab)
                .WhenInjectedInto<IFactory<GameObject>>();

            Container.Bind<IFactory<GameObject>>().To<GameObjectFactory>().AsSingle();

            Container.Bind<int>().FromResolve("PoolSize");
            Container.Bind<IMemoryPool<GameObject>>().To<GameEntityPool>().AsSingle();

            Container.Bind<IFactory<IProjectile, ICommand>>().To<SpawnCommandPool>().AsSingle();

            Container.BindInterfacesTo<TimedCommandExecutor>().AsSingle();
        }
    }
}