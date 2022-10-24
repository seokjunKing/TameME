using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController2 : MonoBehaviour
{
    public GameObject _QuestUI;
    public GameObject _NPCPanel;

    public GameObject Menu;

    public FoxController foxCn;

    public GameObject cam1;
    public GameObject cam2;

    int num_Scene;
    //float timer = 0f;
    //int waitingTime = 1;

    public Slider Slider_LikeAbility_fox;
    public Slider Slider_LikeAbility_rose;

    public bool _isQuestUI = false;

    public bool pChange = false; // 비활성 : 여우 | 활성 : 어린왕자

    int likeability_rose; // 마이너스: 여우 | 플러스 : 장미
    int likeability_fox;

    FadeInOut fade;
    void Start()
    {
        num_Scene = SceneManager.GetActiveScene().buildIndex;

        likeability_fox += DataManager.instance.nowPlayer.pointFox;
        likeability_rose += DataManager.instance.nowPlayer.pointRose;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            SceneManager.LoadScene("MainTitle");
        }

        likeability_fox = (int)Slider_LikeAbility_fox.value;
        likeability_rose = (int)Slider_LikeAbility_rose.value;

        TouchNPC();

        PlayerChange();


    }
    void PlayerChange()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (pChange)
            {
                pChange = false;
                cam1.SetActive(true);
                cam2.SetActive(false);
            }
            else
            {
                pChange = true;
                cam1.SetActive(false);
                cam2.SetActive(true);
            }
        }
    }
    public void OnClickRoseLikeAbillity()
    {
        DataManager.instance.nowPlayer.pointRose += 2;
    }
    public void OnClickFoxLikeAbillity()
    {
        DataManager.instance.nowPlayer.pointFox += 2;
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
        Time.timeScale = 0f;
        fade.OnClickFade();
        SceneManager.LoadScene(num_Scene);
    }
    public void OnClickGoMain()
    {
        Time.timeScale = 1f;
        fade.GoMainFade();
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

    void TouchNPC()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.transform.gameObject.CompareTag("NPC"))
            {
                Time.timeScale = 0f;
                _NPCPanel.SetActive(true);
            }
            else
            {

            }
        }
    }
}
