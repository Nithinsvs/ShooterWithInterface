using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Nithin.SaveSystem
{
    public static class SaveManager
    {
        static string _storagePath = Application.persistentDataPath + "/playerData";

        public static void SavePlayerData(PlayerSaveData savedata)
        {
            string playerDataFile = JsonUtility.ToJson(savedata);
            File.WriteAllText(_storagePath, playerDataFile);
        }

        public static PlayerSaveData LoadPlayerData()
        {
            if(!File.Exists(_storagePath))
            {
                return null;
            }
            string readFile = File.ReadAllText(_storagePath);
            PlayerSaveData loadedPlayerData = JsonUtility.FromJson<PlayerSaveData>(readFile);
            return loadedPlayerData;
        }

    }

    [Serializable]
    public class PlayerSaveData
    {
        public int score;
        public int health;

        public PlayerSaveData()
        {
            score = 0;
            health = 0;
        }
    }
}
