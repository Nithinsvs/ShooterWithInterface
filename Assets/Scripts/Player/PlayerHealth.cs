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

        private int _health = 0;

        private void Awake()
        {
            _health = saveDataScriptableObject.health;
        }

        public void AddHealth(int health)
        {
            _health += health;
            saveDataScriptableObject.health = _health;
            scoreText.text = health.ToString();
        }
    }
}