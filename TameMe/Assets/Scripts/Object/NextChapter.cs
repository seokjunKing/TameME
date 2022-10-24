using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextChapter : MonoBehaviour
{
    public PlayerController player;
    public GameController controller;

    public Image image;
    public GameObject image1;

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FadeInOut());
            image.gameObject.SetActive(true);
            player.isControl = false;
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
        controller.OnClickNextScene();
    }
}
