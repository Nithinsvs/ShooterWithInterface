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


        public static void SavePlayerData(int score)
        {
            PlayerSaveData playerSaveData = new PlayerSaveData();
            playerSaveData.score = score;

            string playerDataFile = JsonUtility.ToJson(playerSaveData);
            File.WriteAllText(_storagePath, playerDataFile);
        }

        public static void LoadPlayerData()
        {
            
            string readFile = File.ReadAllText(_storagePath);
            PlayerSaveData loadedPlayerData = JsonUtility.FromJson<PlayerSaveData>(readFile);
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
