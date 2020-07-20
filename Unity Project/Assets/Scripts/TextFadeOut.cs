using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextFadeOut : MonoBehaviour
{
    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        Invoke("StartFadeOut", 3);
    }

    public void StartFadeOut()
    {
        StartCoroutine("FadeOutText");
    }

    private IEnumerator FadeOutText()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = text.color;
            c.a = f;
            text.color = c;
            yield return new WaitForSeconds(0.05f);
        }

        SceneManager.LoadScene("MainMenuScene");
    }
}
