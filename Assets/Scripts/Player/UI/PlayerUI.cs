using Nithin.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nithin.UI
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private Text _currentScoreValue;
        [SerializeField] private PlayerHealth _playerHealth;

        private void OnEnable()
        {
            PlayerScore.ScoreUpdated += ShowScore;
            _playerHealth.OnHealthChange += ShowHealth;
        }

        private void OnDisable()
        {
            PlayerScore.ScoreUpdated -= ShowScore;
            _playerHealth.OnHealthChange -= ShowHealth;
        }

        private void ShowHealth(int currentHealth)
        {
            //scoreText.text = currentHealth.ToString();
        }

        private void ShowScore(int score)
        {
            _currentScoreValue.text = score.ToString();
        }
    }
}
