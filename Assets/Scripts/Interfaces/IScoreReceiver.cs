using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nithin.Interfaces
{
    public interface IScoreReceiver
    {
        public event Action<int> PlayerScoreGranted;
        public void AddScore(int scoreToAdd);
    }
}