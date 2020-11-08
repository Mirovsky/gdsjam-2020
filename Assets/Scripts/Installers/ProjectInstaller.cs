using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private FadeInOutManager _fadeInOutManagerPrefab = default;
    [SerializeField] private ScenesManager _sceneManagerPrefab = default;
    
    public override void InstallBindings()
    {
        Container.Bind<EndGameDataModel>().FromInstance(new EndGameDataModel()).AsSingle().NonLazy();
        Container.Bind<FadeInOutManager>().FromComponentInNewPrefab(_fadeInOutManagerPrefab).AsSingle().NonLazy();
        Container.Bind<ScenesManager>().FromComponentInNewPrefab(_sceneManagerPrefab).AsSingle().NonLazy();
    }
}
