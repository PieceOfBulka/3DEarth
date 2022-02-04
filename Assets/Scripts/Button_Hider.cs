using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Hider : MonoBehaviour
{
    public GameObject[] buttons;
    public float animDuration = 0.5f;
    bool animplaying;

    public void Hide()
    {
        if (animplaying)
        {
            return;
        }
        if (buttons[0].activeSelf)
        {
            StartCoroutine(FadeOut());
        }
        else
        {
            StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeOut()
    {
        animplaying = true;

        for (float i = 0f; i <= 1f; i += Time.deltaTime / animDuration)
        {
            foreach (GameObject btn in buttons)
            {
                //btn.GetComponent<Image>().color = Color.Lerp(Color.white, Color.clear, i);
                btn.GetComponentInChildren<TextMesh>().color = Color.Lerp(Color.black, Color.clear, i);
            }
            yield return null;

            foreach (GameObject btn in buttons)
            {
                btn.SetActive(false);
            }

            animplaying = false;
        }
    }

    IEnumerator FadeIn()
    {
        animplaying = true;

        foreach (GameObject btn in buttons)
        {
            btn.SetActive(true);
        }

        for (float i = 0f; i <= 1f; i += Time.deltaTime / animDuration)
        {
            foreach (GameObject btn in buttons)
            {
                //btn.GetComponent<Image>().color = Color.Lerp(Color.clear, Color.white, i);
                btn.GetComponentInChildren<TextMesh>().color = Color.Lerp(Color.clear, Color.black, i);
            }
            yield return null;
        }

        animplaying = false;
    }
}
