using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI = default;
    [SerializeField] private GameObject _inGameUI = default;

    [Inject] private ScenesManager _scenesManager = default;

    void Start()
    {
        _inGameUI.SetActive(true);
        _pauseUI.SetActive(false);
    }
    
    public void Pause()
    {
        Time.timeScale = 0;
        
        _inGameUI.SetActive(false);
        _pauseUI.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        
        _inGameUI.SetActive(true);
        _pauseUI.SetActive(false);
    }

    public void Restart()
    {
        var activeScenePath = SceneManager.GetActiveScene().path;
        
        _scenesManager.ToGame(activeScenePath);
    }
}
