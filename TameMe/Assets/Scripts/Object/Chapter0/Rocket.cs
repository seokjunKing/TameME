using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    public Text QuestUIText;
    public Text[] Txt_quest;
    public Toggle[] Tg_quest;

    public Sprite[] img_btnquest;
    public Image img_quest;

    public GameController gameController;

    public FadeInOut fade;

    public GameObject button;

    void Update()
    {
        if (gameController._isPalatte)
        {
            Txt_quest[1].text = "장미 팔레트를 사용해 보세요";
            Tg_quest[1].isOn = true;
        }

        if(Tg_quest[1].isOn && Tg_quest[2].isOn)
        {
            img_quest.sprite = img_btnquest[0];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Txt_quest[2].text = "우주선에 탑승하세요";
            Tg_quest[2].isOn = true;
            Destroy(collision.gameObject);
            button.SetActive(true);
        }
    }
    public void OnClickButton()
    {
        button.SetActive(false);
    }
}
