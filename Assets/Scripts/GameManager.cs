using Nithin.Core;
using Nithin.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event Action<PlayerSaveData> LoadedData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnEnable()
    {
        GameEvents.OnPlayerScoreUpdated += StoreDataAndSaveGame;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerScoreUpdated -= StoreDataAndSaveGame;
    }

    private void Start()
    {
        PlayerSaveData playerSaveData = SaveManager.LoadPlayerData();
        if (playerSaveData == null)
            playerSaveData = new PlayerSaveData();
        GameEvents.OnPlayerDataLoaded(playerSaveData);
    }

    private void StoreDataAndSaveGame(int score)
    {
        PlayerSaveData savedData = new();
        savedData.score = score;
        SaveManager.SavePlayerData(savedData);
    }
}