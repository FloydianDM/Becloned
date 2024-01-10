using Becloned;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private TimeManager _timeManager;

    private void Start()
    {
        _timeManager = FindObjectOfType<TimeManager>();
        _timeManager.OnTimeFinished += ProcessGameOver;
    }

    private void ProcessGameOver()
    {
        SceneManager.LoadScene(0);
    }
}
