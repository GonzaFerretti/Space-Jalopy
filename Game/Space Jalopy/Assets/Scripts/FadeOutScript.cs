using System.Collections;
using UnityEngine;

public class FadeOutScript : MonoBehaviour
{
    SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        Invoke("StartFadeOut", 3);
    }

    private void StartFadeOut()
    {
        StartCoroutine("FadeOut");
    }

    private IEnumerator FadeOut()
    {
        for(float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
