using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nithin.Core
{
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
