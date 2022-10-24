using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quest1_4 : MonoBehaviour
{
    public Toggle[] Tg_quest;

    public Sprite[] img_btnquest;

    public GameController controller;
    public PlayerController player;

    public GameObject StartDialogue;


    void Start()
    {
        if (StartDialogue.activeSelf)
        {
            player.isControl = false;
        }
    }
    public void OnClickDialogueOff()
    {
        StartDialogue.SetActive(false);
        controller.TextBox.SetActive(false);
        player.isControl = true;
    }
}
