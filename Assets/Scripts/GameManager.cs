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

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void ProcessGameOver()
    {
        AdManager.Instance.ShowAd(this);

        LoadMainMenu();
    }
}
