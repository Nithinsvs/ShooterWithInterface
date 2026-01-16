using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour, IScore
{
    public event Action<int> ScoreUpdated;
    public SaveDataObj saveDataScriptableObject;

    private int _score = 0;


    private void Awake()
    {
        _score = saveDataScriptableObject.score;
    }

    public void AddScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        ScoreUpdated?.Invoke(_score);

        saveDataScriptableObject.score = _score;
    }
}
