using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Nithin.Core
{
    public static class SaveManager
    {
        static string _storagePath = Application.persistentDataPath + "/playerData";

        public static void SavePlayerData(PlayerSaveData savedata)
        {
            string playerDataFile = JsonUtility.ToJson(savedata);
            File.WriteAllText(_storagePath, playerDataFile);
            Debug.Log("Saved player data");
        }

        public static PlayerSaveData LoadPlayerData()
        {
            if(!File.Exists(_storagePath))
            {
                return null;
            }
            string readFile = File.ReadAllText(_storagePath);
            PlayerSaveData loadedPlayerData = JsonUtility.FromJson<PlayerSaveData>(readFile);
            Debug.Log("Loaded player data");
            return loadedPlayerData;
        }

    }

   
}
