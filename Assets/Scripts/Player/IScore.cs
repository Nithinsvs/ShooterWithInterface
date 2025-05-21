using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public interface IScore
    {
        public void AddScore(int scoreToAdd);
    }
}