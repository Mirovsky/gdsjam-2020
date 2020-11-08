using ModestTree;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameScenesSO _gameScenes = default;

    [Space]
    [SerializeField] private Button _prevLevelButton = default;
    [SerializeField] private Button _nextLevelButton = default;

    [Space]
    [SerializeField] private GameObject _successScreen = default;
    [SerializeField] private GameObject _failScreen = default;

    [Space]
    [SerializeField] private EndGameMeterManager _endGameMeterManager = default;
    
    [Inject] private ScenesManager _scenesManager = default;
    [Inject] private EndGameDataModel _endGameDataModel = default;
    
    protected void Start()
    {
        _successScreen.SetActive(!_endGameDataModel.gameOver);
        _failScreen.SetActive(_endGameDataModel.gameOver);

        if (!_endGameDataModel.gameOver)
        {
            _endGameMeterManager.Count = _endGameDataModel.count;
            _endGameMeterManager.Score = _endGameDataModel.finalScore;
        }

        var activeSceneIndex = ActiveSceneIndex();
        _prevLevelButton.gameObject.SetActive(activeSceneIndex > 0);
        Debug.Log(_gameScenes.gameScenes.Length - 1);
        _nextLevelButton.gameObject.SetActive(activeSceneIndex < _gameScenes.gameScenes.Length - 1);
    }
    
    public void PrevLevel()
    {
        var activeScene = ActiveSceneIndex();
        _scenesManager.ToGame(_gameScenes.gameScenes[activeScene - 1]);
    }

    public void NextLevel()
    {
        var activeSceneIndex = ActiveSceneIndex();
        _scenesManager.ToGame(_gameScenes.gameScenes[activeSceneIndex + 1]);
    }

    public void Restart()
    {
        var activeSceneIndex = ActiveSceneIndex();
        _scenesManager.ToGame(_gameScenes.gameScenes[activeSceneIndex]);
    }

    public void Menu()
    {
        _scenesManager.ToMenu();
    }

    int ActiveSceneIndex()
    {   
        return _gameScenes.gameScenes.IndexOf(_endGameDataModel.gameScene);
    }
}
