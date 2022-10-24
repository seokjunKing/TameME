using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetRose : MonoBehaviour
{
    public GameObject rose;

    public GameObject getroseText;
    public GameObject textbox;

    public Image fade;

    public PlayerController Player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.isControl = false;
            StartCoroutine(FadeOutCoroutine1());

            rose.SetActive(true);
            
        }
    }
    public void ImageOffFade()
    {
        StartCoroutine(FadeOutCoroutine3());
    }

    IEnumerator FadeOutCoroutine1()
    {
        fade.gameObject.SetActive(true);
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.02f;
            yield return new WaitForSeconds(0.01f);
            fade.color = new Color(0, 0, 0, fadeCount);
        }
        StartCoroutine(FadeInCoroutine2());
    }
    IEnumerator FadeInCoroutine2()
    {
        float fadeCount = 1;
        getroseText.SetActive(true);
        while (fadeCount > 0)
        {
            fadeCount -= 0.02f;
            yield return new WaitForSeconds(0.01f);
            fade.color = new Color(0, 0, 0, fadeCount);
        }
        textbox.SetActive(true);
        fade.gameObject.SetActive(false);
    }
    IEnumerator FadeOutCoroutine3()
    {
        fade.gameObject.SetActive(true);
        textbox.SetActive(false);
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.02f;
            yield return new WaitForSeconds(0.01f);
            fade.color = new Color(0, 0, 0, fadeCount);
        }
        getroseText.SetActive(false);
        StartCoroutine(FadeInCoroutine4());
    }
    IEnumerator FadeInCoroutine4()
    {
        float fadeCount = 1;
        while (fadeCount > 0)
        {
            fadeCount -= 0.02f;
            yield return new WaitForSeconds(0.01f);
            fade.color = new Color(0, 0, 0, fadeCount);
        }
        fade.gameObject.SetActive(false);
        Player.isControl = true;
        gameObject.SetActive(false);
    }
}
