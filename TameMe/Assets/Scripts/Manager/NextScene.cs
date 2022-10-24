using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    int num;

    bool fadeIn = false;

    public Image[] image;

    void Start()
    {
        num = SceneManager.GetActiveScene().buildIndex;

    }
    public void OnClickNextScene()
    {
        SceneManager.LoadScene(num+1);
    }
    public void OnClickJump()
    {
        SceneManager.LoadScene("SelectStage");
    }
    public void OnClickExitGame()
    {
        Application.Quit();
    }
    public void OnClickLoadGame()
    {
        DataManager.instance.LoadData();
        SceneManager.LoadScene(DataManager.instance.nowPlayer.stageNum);
    }
    public void OnClickImage1()
    {
        image[0].gameObject.SetActive(false);
        image[1].gameObject.SetActive(true);
    }
    public void OnClickImage2()
    {
        image[1].gameObject.SetActive(false);
        image[2].gameObject.SetActive(true);
    }
    
    public void OnClickImage1Fade()
    {
        image[0].gameObject.SetActive(true);
        image[1].gameObject.SetActive(false);
        image[2].gameObject.SetActive(false);
    }
    public void OnClickImage2Fade()
    {
        image[0].gameObject.SetActive(false);
        image[1].gameObject.SetActive(true);
        image[2].gameObject.SetActive(false);
    }
    public void OnClickImage3Fade()
    {
        image[0].gameObject.SetActive(false);
        image[1].gameObject.SetActive(false);
        image[2].gameObject.SetActive(true);
    }

    public void OnClickImage11Fade()
    {
        image[3].gameObject.SetActive(true);
        image[4].gameObject.SetActive(false);
        image[5].gameObject.SetActive(false);
    }
    public void OnClickImage22Fade()
    {
        image[3].gameObject.SetActive(false);
        image[4].gameObject.SetActive(true);
        image[5].gameObject.SetActive(false);
    }
    public void OnClickImage33Fade()
    {
        image[3].gameObject.SetActive(false);
        image[4].gameObject.SetActive(false);
        image[5].gameObject.SetActive(true);
    }



    IEnumerator Image1Fade()
    {
        if (fadeIn)
        {
            float fadeCount = 0;
            while (fadeCount < 0.5f)
            {
                fadeCount += 0.025f;
                yield return new WaitForSeconds(0.01f);
                image[0].color = new Color(0, 0, 0, fadeCount);
            }
        }
        else
        {
            float fadeCount = 0;
            while (fadeCount > 0.5f)
            {
                fadeCount -= 0.025f;
                yield return new WaitForSeconds(0.01f);
                image[0].color = new Color(0, 0, 0, fadeCount);
            }
        }
    }

    IEnumerator Image2Fade()
    {
        if (fadeIn)
        {
            float fadeCount = 0;
            while (fadeCount < 0.5f)
            {
                fadeCount += 0.025f;
                yield return new WaitForSeconds(0.01f);
                image[1].color = new Color(0, 0, 0, fadeCount);
            }
        }
        else
        {
            float fadeCount = 0;
            while (fadeCount > 0.5f)
            {
                fadeCount -= 0.025f;
                yield return new WaitForSeconds(0.01f);
                image[1].color = new Color(0, 0, 0, fadeCount);
            }
        }
    }
}