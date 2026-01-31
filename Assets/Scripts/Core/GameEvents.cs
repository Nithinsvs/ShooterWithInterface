using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nithin.Core
{
    public static class GameEvents
    {
        public static Action<PlayerSaveData> OnPlayerSaveDataLoaded;
        public static Action<int> OnPlayerScoreUpdated;

        public static void OnPlayerDataLoaded(PlayerSaveData playerSaveData)
        {
            OnPlayerSaveDataLoaded?.Invoke(playerSaveData);
            Debug.Log(playerSaveData.score);
        }

        public static void OnScoreUpdated(int score)
        {
            OnPlayerScoreUpdated?.Invoke(score);
        }
    }
}