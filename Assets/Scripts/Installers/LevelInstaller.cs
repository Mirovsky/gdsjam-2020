using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private LevelArea _levelArea = default;
    [SerializeField] private GamePositionsManager _gamePositionsManager = default;
    
    public override void InstallBindings()
    {
        Container.Bind<GamePositionsManager>().FromInstance(_gamePositionsManager);
        Container.Bind<LevelArea>().FromInstance(_levelArea);
    }
}
