using Game.Core.Common;
using Game.Core.Entities;
using Game.Core.Entities.ProjectileBuilders;
using Game.Core.Interfaces;
using Game.Core.SpawnControllers;
using Game.Settings;
using UnityEngine;
using Zenject;

namespace Game.Installers.GameProcess
{
    public class PlayerSpawnerInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<SpawnController>().AsSingle();

            Container.Bind<float>().FromResolveGetter<PlayerSettings>(settings => settings.Cooldown);

            Container.Bind<GameObject>().FromResolveGetter<PlayerSettings>(settings => settings.Projectile)
                .WhenInjectedInto<IFactory<GameObject>>();

            Container.Bind<IBuildPipeline<GameObject>>()
                .FromResolveGetter<PlayerSettings>(settings => new SpeedComponentBuilder(settings.ProjectileSpeed))
                .AsSingle();

            Container.Bind<IFactory<Vector2, Vector2, IProjectile>>().To<ProjectilesFactory>().AsSingle();

            Container.Bind<IFactory<GameObject>>().To<GameObjectFactory>().AsSingle();
            Container.Bind<int>().FromResolve("PoolSize");
            Container.Bind<IMemoryPool<GameObject>>().To<GameEntityPool>().AsSingle();


            Container.Bind<IFactory<IProjectile, ICommand>>().To<SpawnCommandPool>().AsSingle();

            Container.BindInterfacesTo<TimedCommandExecutor>().AsSingle();
        }
    }
}