using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        public SaveDataObj saveDataScriptableObject;
        [SerializeField] private Text scoreText;

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

        private void Awake()
        {
            _health = saveDataScriptableObject.health;
        }

        public void AddHealth(int health)
        {
            Health += health;
            saveDataScriptableObject.health = Health;
            scoreText.text = health.ToString();
        }
    }
}