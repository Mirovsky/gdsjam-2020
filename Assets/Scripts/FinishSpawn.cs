using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FinishSpawn : MonoBehaviour
{
    [Inject] private GamePositionsManager _gamePositionsManager = default;
    
    void Start()
    {
        transform.position = _gamePositionsManager.playerFinish.position;
    }
}
