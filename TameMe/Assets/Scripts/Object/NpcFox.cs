using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcFox : MonoBehaviour
{
    public GameController Controller;
    public PlayerController Player;

    public GameObject Dialogue;
    public GameObject textBox;

    public Image image;
    public GameObject image1;

    public GameObject Fox2;



    public void OnClickFade()
    {
        Dialogue.SetActive(false);
        textBox.SetActive(false);
        image.gameObject.SetActive(true);
        StartCoroutine(FadeInOut());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Dialogue.SetActive(true);
            textBox.SetActive(true);
            Player.isControl = false;
        }
    }

    
    IEnumerator FadeInOut()
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.02f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        image1.SetActive(true);
        while (fadeCount > 0)
        {
            fadeCount -= 0.02f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        yield return new WaitForSeconds(3f);
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.02f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        image1.SetActive(false);
        while (fadeCount > 0)
        {
            fadeCount -= 0.02f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        image.gameObject.SetActive(false);
        StartCoroutine(ChangeFox());
    }

    IEnumerator ChangeFox()
    {
        Fox2.SetActive(true);
        yield return new WaitForSeconds(0.01f);
        gameObject.SetActive(false);
    }
}
