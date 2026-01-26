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

        private int _score = 0;

        private void Start()
        {
            PlayerSaveData savedData = SaveManager.LoadPlayerData();
            if(savedData == null)
            {
                return;
            }
            ScoreUpdated?.Invoke(savedData.score);
        }

        public void AddScore(int scoreToAdd)
        {
            _score += scoreToAdd;
            ScoreUpdated?.Invoke(_score);
        }
    }
}
