using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Scene");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }
}
