using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject _palatte;
    public GameObject Btn_palatte;
    public GameObject _QuestUI;
    public GameObject _NPCPanel;
    public GameObject TextBox;
    public GameObject Menu;

    public Sprite[] img_btnColor;
    public Image img_btn;

    int num_Scene;
    //float timer = 0f;
    //int waitingTime = 1;

    public Slider Slider_LikeAbility_fox;
    public Slider Slider_LikeAbility_rose;

    public bool _isPalatte = false;
    public bool _isQuestUI = false;

    public bool _isBlack = true;
    public bool _isBlue = false;
    public bool _isGreen = false;

    public int likeability_rose;
    public int likeability_fox;

    public bool isFox = false;

    public FadeInOut fade;

    private void Awake()
    {
        DataManager.instance.LoadData();
        likeability_fox = DataManager.instance.nowPlayer.pointFox;
        likeability_rose = DataManager.instance.nowPlayer.pointRose;
        Debug.Log(likeability_rose);
    }

    void Start()
    {
        DataManager.instance.SaveData();
        num_Scene = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Menu.activeSelf)
            {
                Time.timeScale = 1f;
                Menu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0f;
                Menu.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            SceneManager.LoadScene("MainTitle");
        }

        Slider_LikeAbility_fox.value = likeability_fox;
        Slider_LikeAbility_rose.value = likeability_rose;
    }

    public void OnClickPalatteOn()
    {
        Btn_palatte.SetActive(false);
        _isPalatte=true;
        _palatte.SetActive(true);

    }
    public void OnClickPalatteOff()
    {
        _isPalatte = false;
        Btn_palatte.SetActive(true);
    }

    public void OnClickChooseColorBlack()
    {
        _isBlack = true;
        _isBlue = false;
        _isGreen = false;
        Debug.Log("Black");
        _palatte.SetActive(false);
        img_btn.sprite = img_btnColor[0];
    }
    public void OnClickChooseColorBlue()
    {
        _isBlue = true;
        _isBlack = false;
        _isGreen = false;
        Debug.Log("Blue");
        _isPalatte = false;
        _palatte.SetActive(false);
        img_btn.sprite = img_btnColor[1];
    }
    public void OnClickChooseColorGreen()
    {
        _isGreen = true;
        _isBlue = false;
        _isBlack = false;
        Debug.Log("Green");
        _isPalatte = false;
        _palatte.SetActive(false);
        img_btn.sprite = img_btnColor[2];
    }
    public void OnClickRoseLikeAbillity()
    {
        DataManager.instance.nowPlayer.pointRose += 10;
        DataManager.instance.SaveData();
        Time.timeScale = 1f;
    }
    public void OnClickRoseLikeAbillityMinus()
    {
        DataManager.instance.nowPlayer.pointRose -= 10;
        DataManager.instance.SaveData();
        Time.timeScale = 1f;
    }
    public void OnClickFoxLikeAbillity()
    {
        DataManager.instance.nowPlayer.pointFox += 10;
        DataManager.instance.SaveData();
        Time.timeScale = 1f;
    }
    public void OnClickFoxLikeAbillityMinus()
    {
        DataManager.instance.nowPlayer.pointFox -= 10;
        DataManager.instance.SaveData();
        Time.timeScale = 1f;
    }

    public void OnClickQuestUIOn()
    {
        Time.timeScale = 0f;
        _isQuestUI = true;
        _QuestUI.SetActive(true);
    }
    public void OnClickQuestUIOff()
    {
        Time.timeScale = 1f;
        _isQuestUI = false;
        _QuestUI.SetActive(false);
    }
    public void OnClickNextScene()
    {
        Time.timeScale = 1f;
        fade.OnClickFade();
    }
    public void OnClickReplay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(num_Scene);
    }
    public void OnClickGoMain()
    {
        Time.timeScale = 1f;
        fade.GoMainFade();
    }
    public void OnClickMenuOn()
    {
        Time.timeScale = 0f;
        Menu.SetActive(true);
    }
    public void OnClickMenuOff()
    {
        Time.timeScale = 1f;
        Menu.SetActive(false);
    }
    public void OnClickExit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void potion()
    {
        _NPCPanel.SetActive(true);
        TextBox.SetActive(true);
    }
}
