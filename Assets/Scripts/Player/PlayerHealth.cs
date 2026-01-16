using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nithin.Player
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        public event Action<int> OnHealthChange;

        private int _health;
        public int Health
        {
            get
            {
                return _health;
            }

            set
            {
                if (value < 0)
                {
                    throw new Exception("Health cannot be less than 0");
                }
                _health = value;
            }
        }

        public void AddHealth(int health)
        {
            Health += health;
            OnHealthChange?.Invoke(health);
        }
    }
}