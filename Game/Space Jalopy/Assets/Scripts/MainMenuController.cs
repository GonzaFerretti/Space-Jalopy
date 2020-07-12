using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject _soundManager;

    private void Start()
    {
        _soundManager.GetComponent<soundManager>().PlayBGM(BGM.Menu);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
