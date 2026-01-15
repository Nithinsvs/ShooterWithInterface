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
        [SerializeField] private PlayerScore playerScore;

        [SerializeField] private PlayerHealth playerHealth;


        private void OnEnable()
        {
            playerScore.ScoreUpdated += ShowScore;
            playerHealth.OnHealthChange += ShowHealth;
        }

        private void ShowHealth(int currentHealth)
        {
            //scoreText.text = currentHealth.ToString();
        }

        private void ShowScore(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}
