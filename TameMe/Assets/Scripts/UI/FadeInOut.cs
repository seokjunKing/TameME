using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    public Image image;

    int num_Scene;

    private void Start()
    {
        num_Scene = SceneManager.GetActiveScene().buildIndex;
        image.gameObject.SetActive(true);
        StartCoroutine(FadeInCoroutine());
    }

    public void OnClickFade()
    {
        StartCoroutine(FadeOutCoroutine());
        image.gameObject.SetActive(true);
    }
    public void OnClickFadeMain()
    {
        StartCoroutine(MainFadeOutCoroutine());
        image.gameObject.SetActive(true);
    }
    public void FadeIn()
    {
        image.gameObject.SetActive(true);
        StartCoroutine(FadeInCoroutine());
    }

    public void FadeOut()
    {
        image.gameObject.SetActive(true);
        StartCoroutine(FadeOutCoroutineRespawn());
    }
    public void GoMainFade()
    {
        image.gameObject.SetActive(true);
        StartCoroutine(GoMainFadeOutCoroutine());
    }
    public void LoadFade()
    {
        image.gameObject.SetActive(true);
        StartCoroutine(LoadFadeOut());
    }
    IEnumerator LoadFadeOut()
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        DataManager.instance.LoadData();
        SceneManager.LoadScene(DataManager.instance.nowPlayer.stageNum);
    }

    IEnumerator FadeOutCoroutineRespawn()
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.025f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        StartCoroutine(FadeInCoroutine());
    }


    IEnumerator FadeOutCoroutine()
    {
        float fadeCount = 0;
        while(fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        SceneManager.LoadScene(num_Scene+1);
    }

    IEnumerator MainFadeOutCoroutine()
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        SceneManager.LoadScene(num_Scene + 2);
    }

    IEnumerator GoMainFadeOutCoroutine()
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        SceneManager.LoadScene("MainTitle");
    }


    IEnumerator FadeInCoroutine()
    {
        float fadeCount = 1;
        while (fadeCount > 0)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        image.gameObject.SetActive(false);
    }
}
