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

        }

       /* private void SetScore(PlayerSaveData currentData)
        {
            ScoreUpdated?.Invoke(currentData.score);
        }*/

        public void AddScore(int scoreToAdd)
        {
            _score += scoreToAdd;
            ScoreUpdated?.Invoke(_score);
        }
    }
}
