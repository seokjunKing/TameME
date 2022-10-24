using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rose : MonoBehaviour
{
    int num_scene;

    public Image[] image;

    public GameObject ImageText;

    public PlayerController player;

    public GameObject[] Typing;
    public GameObject textbox;

    private void Start()
    {
        num_scene = SceneManager.GetActiveScene().buildIndex;
    }

    public void Image2Fade()
    {
        textbox.SetActive(false);
        StartCoroutine(FadeInCoroutine2());
    }
    public void Image3Fade()
    {
        textbox.SetActive(false);
        StartCoroutine(FadeOutCoroutine3());
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (num_scene == 3)
            {
                StartCoroutine(FadeOutCoroutine1());
                player.isControl = false;
            }
            else 
            {
                ImageText.SetActive(true);
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (num_scene == 3)
            {
                
            }
            else
            {
                ImageText.SetActive(true);
            }
        }
    }

    IEnumerator FadeOutCoroutine1() // 1. 페이드아웃
    {
        image[0].gameObject.SetActive(true);
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.02f;
            yield return new WaitForSeconds(0.01f);
            image[0].color = new Color(0, 0, 0, fadeCount);
        }
        textbox.SetActive(true);
        Typing[0].SetActive(true);
    }
    IEnumerator FadeInCoroutine2() // 2.페이드인 & 이미지1
    {
        Typing[0].SetActive(false);
        Typing[1].SetActive(true);
        float fadeCount = 1;
        while (fadeCount > 0)
        {
            fadeCount -= 0.02f;
            yield return new WaitForSeconds(0.01f);
            image[0].color = new Color(0, 0, 0, fadeCount);
        }
        image[0].gameObject.SetActive(false);
        textbox.SetActive(true);
    }
    IEnumerator FadeOutCoroutine3()
    {
        image[0].gameObject.SetActive(true);
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.02f;
            yield return new WaitForSeconds(0.01f);
            image[0].color = new Color(0, 0, 0, fadeCount);
        }
        StartCoroutine(FadeInCoroutine4());
    }
    IEnumerator FadeInCoroutine4()
    {
        image[1].gameObject.SetActive(false);
        image[2].gameObject.SetActive(true);
        Typing[1].SetActive(false);
        Typing[2].SetActive(true);
        float fadeCount = 1;
        while (fadeCount > 0)
        {
            fadeCount -= 0.02f;
            yield return new WaitForSeconds(0.01f);
            image[0].color = new Color(0, 0, 0, fadeCount);
        }
        image[0].gameObject.SetActive(false);
        textbox.SetActive(true);
    }
    IEnumerator FadeOutCoroutine5()
    {
        image[0].gameObject.SetActive(true);
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.02f;
            yield return new WaitForSeconds(0.01f);
            image[0].color = new Color(0, 0, 0, fadeCount);
        }
        SceneManager.LoadScene("Chapter0-1");
    }
}
