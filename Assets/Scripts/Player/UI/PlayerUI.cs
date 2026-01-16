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
        [SerializeField] private PlayerScore _playerScore;

        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private SaveDataObj _saveDataObj;

        private int _score;

        private void Awake()
        {
            _score = _saveDataObj.score;
            ShowScore(_score);
        }

        private void OnEnable()
        {
            _playerScore.ScoreUpdated += ShowScore;
            _playerHealth.OnHealthChange += ShowHealth;
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
