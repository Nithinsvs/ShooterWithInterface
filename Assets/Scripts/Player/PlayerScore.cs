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
            GameEvents.OnPlayerSaveDataLoaded -= SetScore;
        }

        private void SetScore(PlayerSaveData currentData)
        {
            _score = currentData != null ? currentData.score : 0;
            ScoreUpdated?.Invoke(_score);
        }

        public void AddScore(int scoreToAdd)
        {
            _score += scoreToAdd;
            ScoreUpdated?.Invoke(_score);
            GameEvents.OnScoreUpdated(_score);
        }
    }
}
