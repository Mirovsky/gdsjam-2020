using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/GameScenesSO")]
public class GameScenesSO : ScriptableObject
{
    [SerializeField] private string[] _gameScenes = default;

    public string[] gameScenes => _gameScenes;
}
