using UnityEngine;
using Zenject;

public class DataModelsInstaller : MonoInstaller
{
    [SerializeField] private TruthDataSO _truthData = default;
    [SerializeField] private TruthDataModel _truthDataModelPrefab = default;
    
    public override void InstallBindings()
    {
        Container.Bind<TruthDataModel>().FromComponentInNewPrefab(_truthDataModelPrefab).AsSingle();
    }
}
