using Nithin.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nithin.UI
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private PlayerHealth playerHealth;


        private void OnEnable()
        {
            playerHealth.OnHealthChange += ShowUI;
        }

        private void ShowUI(int currentHealth)
        {
            scoreText.text = currentHealth.ToString();
        }
    }
}
