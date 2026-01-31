using Nithin.Core;
using Nithin.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nithin.Player
{
    public class PlayerScore : MonoBehaviour, IScoreReceiver
    {
        public static event Action<int> ScoreUpdated;
        public event Action<int> PlayerScoreGranted;

        private int _score = 0;

        private void OnEnable()
        {
            GameEvents.OnPlayerSaveDataLoaded += SetScore;
        }

        private void OnDisable()
        {
            PlayerSaveData playerSaveData = new();
            playerSaveData.score = _score;

            GameEvents.OnScoreUpdated(_score);
            GameEvents.OnPlayerSaveDataLoaded -= SetScore;
        }

        private void SetScore(PlayerSaveData currentData)
        {
            _score = currentData.score;
            ScoreUpdated?.Invoke(_score);
        }

        public void AddScore(int scoreToAdd)
        {
            _score += scoreToAdd;
            ScoreUpdated?.Invoke(_score);
        }
    }
}
