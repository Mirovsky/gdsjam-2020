using UnityEngine;
using Zenject;


public class DefaultInstaller : MonoInstaller
{
    [SerializeField] private TruthDataModel _truthDataModelPrefab = default;
    [SerializeField] private SoundTruthManager _soundTruthManagerPrefab = default;
    [SerializeField] private GameManager _gameManagerPrefab = default;
    
    public override void InstallBindings()
    {
        Container.Bind<TruthDataModel>().FromComponentInNewPrefab(_truthDataModelPrefab).AsSingle().NonLazy();
        Container.Bind<SoundTruthManager>().FromComponentInNewPrefab(_soundTruthManagerPrefab).AsSingle().NonLazy();
        Container.Bind<GameManager>().FromComponentInNewPrefab(_gameManagerPrefab).AsSingle().NonLazy();
    }
}
