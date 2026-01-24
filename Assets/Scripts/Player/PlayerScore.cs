using Nithin.Interfaces;
using Nithin.SaveSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nithin.Player
{
    public class PlayerScore : MonoBehaviour, IScoreReceiver
    {
        public static event Action<int> ScoreUpdated;
        public SaveDataObj saveDataScriptableObject;
        public PlayerSaveData playerSaveData;

        private int _score = 0;


        private void Awake()
        {
            _score = saveDataScriptableObject.score;
        }
        private void Start()
        {
            SaveManager.LoadPlayerData();
        }

        public void AddScore(int scoreToAdd)
        {
            _score += scoreToAdd;
            ScoreUpdated?.Invoke(_score);

            saveDataScriptableObject.score = _score;
            playerSaveData = new();
            playerSaveData.score = scoreToAdd;
            //SaveManager.SavePlayerData(playerSaveData);
        }
    }
}
