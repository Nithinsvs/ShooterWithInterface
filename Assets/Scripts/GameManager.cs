using Nithin.Core;
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
            PlayerSaveData playerSaveData = new();
            playerSaveData = SaveManager.LoadPlayerData();
            LoadedData?.Invoke(playerSaveData);
        
        }

        private void SaveGame(int score)
        {
            PlayerSaveData savedData = new();
            savedData.score = score;
            SaveManager.SavePlayerData(savedData);
        }
    }