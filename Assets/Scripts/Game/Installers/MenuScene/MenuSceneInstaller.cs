using Game.Core.Player.Controllers;
using Zenject;

namespace Game.Installers.MenuScene
{
    public class MenuSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerScoreController>().AsSingle();
        }
    }
}
