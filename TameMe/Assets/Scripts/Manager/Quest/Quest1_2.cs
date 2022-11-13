using UnityEngine;
using UnityEngine.UI;

public class Quest1_2 : MonoBehaviour
{
    public Text[] Txt_quest;
    public Toggle[] Tg_quest;

    public Sprite[] img_btnquest;
    public Image img_quest;

    public Image img_palatteBtn;

    public GameObject rose;

    public GameController2 controller;

    void Update()
    {
        if (controller._isQuestUI && (!Tg_quest[0].isOn || !Tg_quest[1].isOn))
        {
            img_quest.sprite = img_btnquest[1];
        }

        if (rose.gameObject.activeSelf == false)
        {
            img_quest.sprite = img_btnquest[2];
            Txt_quest[0].text = "파란 장미를 찾아보자.";
            Tg_quest[0].isOn = true;

            Txt_quest[1].gameObject.SetActive(true);

            //StartCoroutine(Blink());



        }

        //if (controller._isBlue)
        //{
        //    Txt_quest[1].text = "파란 장미를 사용해보자.";
        //    Tg_quest[1].isOn = true;
        //}

        if (Tg_quest[0].isOn && Tg_quest[1].isOn)
        {
            img_quest.sprite = img_btnquest[0];
        }

        //IEnumerator Blink()
        //{
        //    while (!controller._isQuestUI)
        //    {
        //        img_palatteBtn.color = new Color(1, 1, 1, 1);
        //        yield return new WaitForSeconds(2f);
        //        img_palatteBtn.color = new Color(1, 1, 1, 0.5f);
        //        yield return new WaitForSeconds(2f);

        //    }
        //}
    }
}
