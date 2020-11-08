using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class ScenesManager : MonoBehaviour
{
    [SerializeField] private string _menuScene = default;
    [SerializeField] private string _endGameScene = default;
    [SerializeField] private GameScenesSO _gameScenes = default;
    
    [Inject] private FadeInOutManager _fadeInOutManager = default;
    
    public void ToMenu()
    {
        SwitchScene(_menuScene);
    }

    public void ToGame(string gameScene)
    {
        SwitchScene(gameScene);
    }

    public void ToEndGame()
    {
        SwitchScene(_endGameScene);
    }

    private void SwitchScene(string scenePath)
    {
        _fadeInOutManager.FadeOut(() =>
        {
            SceneManager.LoadScene(scenePath);
        });
    }
}
