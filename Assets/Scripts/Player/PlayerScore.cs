using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour, IScore
{
    public event Action<int> ScoreUpdated;
    private int score = 0;

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        ScoreUpdated?.Invoke(score);
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}
