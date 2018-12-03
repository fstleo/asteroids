using Game.Core.Player.Controllers;
using Game.Core.SpawnControllers;
using Game.Settings;
using UnityEngine;
using Zenject;

namespace Game.Installers.GameProcess
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Camera _mainCamera;

        [SerializeField] private Transform _playerOriginTransform;

        [SerializeField] private int _poolSize;

        public override void InstallBindings()
        {
            Container.BindInstance(_poolSize).WithId("PoolSize");
            Container.Bind<Camera>().FromInstance(_mainCamera).AsSingle();
            Container.Bind<Transform>().FromInstance(_playerOriginTransform).AsSingle();
            Container.Bind<PlayerSettings>().FromResource("Settings/PlayerSettings").AsSingle();
            Container.BindInterfacesTo<PlayerScoreController>().AsSingle();
            Container.Bind<SpawnController>().FromSubContainerResolve()
                .ByNewGameObjectInstaller<EnemySpawnerInstaller>().AsTransient().NonLazy();

            Container.Bind<SpawnController>().FromSubContainerResolve()
                .ByNewGameObjectInstaller<PlayerSpawnerInstaller>().AsTransient().WithConcreteId("Player").NonLazy();


            Container.BindInterfacesAndSelfTo<PlayerLiveController>().AsSingle();
        }
    }
}