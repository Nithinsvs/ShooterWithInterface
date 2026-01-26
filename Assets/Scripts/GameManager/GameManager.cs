using Nithin.Player;
using Nithin.SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void OnEnable()
    {
        PlayerScore.ScoreUpdated += SaveGame;
    }

    private void OnDisable()
    {
        PlayerScore.ScoreUpdated -= SaveGame;
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void SaveGame(int score)
    {
        PlayerSaveData savedData = new();
        savedData.score = score;
        SaveManager.SavePlayerData(savedData);
    }
}
