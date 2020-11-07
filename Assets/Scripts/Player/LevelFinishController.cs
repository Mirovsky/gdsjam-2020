using UnityEngine;
using Zenject;

public class LevelFinishController : MonoBehaviour
{
    [SerializeField] private string _playerTag = default;

    [Inject] private GameManager _gameManager = default;
    
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(_playerTag))
        {
            return;
        }
        
        _gameManager.FinishGame();
    }
}
