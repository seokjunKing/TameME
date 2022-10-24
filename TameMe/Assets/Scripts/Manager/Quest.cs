using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quest : MonoBehaviour
{
    public Text[] Txt_quest;
    public Toggle[] Tg_quest;

    public Sprite[] img_btnquest;
    public Image img_quest;

    public Image img_palatteBtn;

    public GameObject rose;

    public GameController controller;
    public PlayerController player;

    public GameObject StartDialogue;

    void Start()
    {
        player.isControl = false;
    }

    void Update()
    {
        if (controller._isQuestUI && (!Tg_quest[0].isOn || !Tg_quest[1].isOn))
        {
            img_quest.sprite = img_btnquest[1];
        }

        if (rose.gameObject.activeSelf == false)
        {
            img_quest.sprite = img_btnquest[2];
            Tg_quest[0].isOn = true;
            Txt_quest[1].gameObject.SetActive(true);
        }
        if (Tg_quest[0].isOn && Tg_quest[1].isOn)
        {
            img_quest.sprite = img_btnquest[0];
        }
    }

    public void OnClickDialogueOff()
    {
        StartDialogue.SetActive(false);
        controller.TextBox.SetActive(false);
        player.isControl = true;
    }
}
