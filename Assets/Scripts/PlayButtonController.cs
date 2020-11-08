using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayButtonController : MonoBehaviour
{
    [SerializeField] private Button _playButton = default;
    [SerializeField] private GameScenesSO _gameScenes = default;
    
    [Inject] private ScenesManager _scenesManager = default;
    [Inject] private FadeInOutManager _fadeInOutManager = default;
    
    void Start()
    {
        _playButton.onClick.RemoveListener(HandlePlayButtonClick);
        _playButton.onClick.AddListener(HandlePlayButtonClick);
        
        _fadeInOutManager.FadeIn(null);
    }

    private void HandlePlayButtonClick()
    {
        _scenesManager.ToGame(_gameScenes.gameScenes[0]);
    }

    private void OnDestroy()
    {
        _playButton.onClick.RemoveListener(HandlePlayButtonClick);
    }
}
