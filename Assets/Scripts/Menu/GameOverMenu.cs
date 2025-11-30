using Assets.Scripts.Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Button restart;
    [SerializeField] private Button mainMenu;

    private void Start()
    {
        SignalBus.Instance.OnGameOver.AddListener(ShowMenu);
        restart.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if (SignalBus.Instance != null)
        {
            SignalBus.Instance.OnGameOver.RemoveListener(ShowMenu);
        }
    }

    private void ShowMenu()
    {
        SignalBus.Instance.PausePerformedFromCode.Invoke();
        restart.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
