using UnityEngine;
using Zenject;

public class LevelFinishController : MonoBehaviour
{
    [SerializeField] private string _levelFinishTag = default;

    [Inject] private GameManager _gameManager = default;
    
    protected void OnTriggerEnter2D(Collider2D other)
    {   
        if (!other.CompareTag(_levelFinishTag))
        {
            return;
        }
        
        _gameManager.FinishGame();
    }
}
