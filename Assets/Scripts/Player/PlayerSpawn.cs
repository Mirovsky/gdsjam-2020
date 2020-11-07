using UnityEngine;
using Zenject;

public class PlayerSpawn : MonoBehaviour
{
    [Inject] private GamePositionsManager _gamePositionsManager = default;

    protected void Start()
    {
        transform.position = _gamePositionsManager.playerSpawn.position;
    }
}
