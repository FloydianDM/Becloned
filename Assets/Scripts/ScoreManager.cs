using System; 
using UnityEngine;

namespace Becloned
{
    public class ScoreManager : MonoBehaviour
    {
        // if matches found, add points, moving without finding any match causes score decrease

        public int Score { get; private set; }
        public const string HighScoreKey = "High Score";
        public event Action OnScoreChanged;

        private void Start()
        {
            Score = 0;
        }

        public void ChangeScore(int points)
        {
            if (Score + points >= 0) // to prevent score reducing from 0 to minus values
            {
                Score += points;
            }

            if (OnScoreChanged != null)
            {
                OnScoreChanged();
            }
        }

        private void OnDestroy()
        {
            int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

            if (Score > currentHighScore)
            {
                PlayerPrefs.SetInt(HighScoreKey, Score);
            }            
        }
    }
}
