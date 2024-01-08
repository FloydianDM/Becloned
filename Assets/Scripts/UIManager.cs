using Becloned;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private ScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        _scoreManager.OnScoreChanged += ShowScore;       

        ShowScore();
    }

    private void ShowScore()
    {
        _scoreText.text = $"Score: {_scoreManager.Score}";
    }
}
