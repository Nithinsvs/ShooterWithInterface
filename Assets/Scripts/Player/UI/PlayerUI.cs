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
        }

        private void OnDisable()
        {
            PlayerScore.ScoreUpdated -= ShowScore;
        }

        private void ShowScore(int score)
        {
            _currentScoreValue.text = score.ToString();
        }
    }
}
