using Zenject;

namespace ShootEmUp
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyPositions>().AsSingle();
            Container.Bind<SceneSwitcher>().AsSingle();
            Container.Bind<GameManager>().AsSingle();
        }
    }
}