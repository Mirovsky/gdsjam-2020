using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePositionsManager : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawn = default;
    [SerializeField] private Transform _playerFinish = default;

    public Transform playerSpawn => _playerSpawn;
    public Transform playerFinish => _playerFinish;
}
