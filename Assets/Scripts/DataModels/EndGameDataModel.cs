using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameDataModel
{
    public float finalScore;

    public void SetScore(float finalScore)
    {
        this.finalScore = finalScore;
    }

    public void Clear()
    {
        this.finalScore = default;
    }
}
