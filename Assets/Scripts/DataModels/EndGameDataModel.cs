using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameDataModel
{
    public int count;
    public float finalScore;
    public bool gameOver;
    public string gameScene;

    public void SetScore(float finalScore)
    {
        this.finalScore = finalScore;
    }

    public void Clear()
    {
        this.gameScene = SceneManager.GetActiveScene().path;
        
        this.finalScore = default;
        this.gameOver = default;
    }
}
