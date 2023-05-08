using Game;
using Save;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SessionManager>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<SaveSystem>().FromNew().AsSingle().NonLazy();
    }
}