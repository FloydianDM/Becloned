using System;
using TMPro;
using UnityEngine;

namespace Becloned
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private TextMeshProUGUI _highScoreText;

        private ScoreManager _scoreManager;
        private TimeManager _timeManager;

        private void Start()
        {
            _scoreManager = FindObjectOfType<ScoreManager>();
            _scoreManager.OnScoreChanged += ShowScore;       

            _timeManager = FindObjectOfType<TimeManager>();

            ShowScore();
            ShowHighScore();
        }

        private void Update()
        {
            ShowTimer();
        }

        private void ShowScore()
        {
            _scoreText.text = $"Score: {_scoreManager.Score}";
        }

        private void ShowTimer()
        {
            double time = Math.Floor((double)_timeManager.Timer);
            _timerText.text = $"Time Left: {time}";
        }

        private void ShowHighScore()
        {
            _highScoreText.text = $"High Score: {PlayerPrefs.GetInt(ScoreManager.HighScoreKey, 0)}";
        }
    }
}
