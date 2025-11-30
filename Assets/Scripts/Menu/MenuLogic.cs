using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{

    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject tutorialPanel;
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void CreditsShow()
    {
        creditsPanel.SetActive(true);
    }

    public void CreditsHide()
    {
        creditsPanel.SetActive(false);
    }

    public void TutorialShow()
    {
        tutorialPanel.SetActive(true);
    }

    public void TutorialHide()
    {
        tutorialPanel.SetActive(false);
    }
    
}
