using UnityEngine;
using Zenject;


public class DefaultInstaller : MonoInstaller
{
    [SerializeField] private TruthDataModel _truthDataModelPrefab = default;
    [SerializeField] private SoundTruthManager _soundTruthManagerPrefab = default;
    [SerializeField] private FadeInOutManager _fadeInOutManagerPrefab = default;
    [SerializeField] private GameManager _gameManagerPrefab = default;
    
    public override void InstallBindings()
    {
        Container.Bind<TruthDataModel>().FromComponentInNewPrefab(_truthDataModelPrefab).AsSingle();
        Container.Bind<SoundTruthManager>().FromComponentInNewPrefab(_soundTruthManagerPrefab).AsSingle();
        Container.Bind<FadeInOutManager>().FromComponentInNewPrefab(_fadeInOutManagerPrefab).AsSingle();
        Container.Bind<GameManager>().FromComponentInNewPrefab(_gameManagerPrefab).AsSingle();
    }
}
