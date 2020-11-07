using UnityEngine;
using Zenject;


public class DataModelsInstaller : MonoInstaller
{
    [SerializeField] private TruthDataModel _truthDataModelPrefab = default;
    [SerializeField] private SoundTruthManager _soundTruthManagerPrefab = default;
    [SerializeField] private LevelArea _levelArea = default;
    
    
    public override void InstallBindings()
    {
        Container.Bind<TruthDataModel>().FromComponentInNewPrefab(_truthDataModelPrefab).AsSingle();
        Container.Bind<SoundTruthManager>().FromComponentInNewPrefab(_soundTruthManagerPrefab).AsSingle();
        Container.Bind<LevelArea>().FromInstance(_levelArea);
    }
}
