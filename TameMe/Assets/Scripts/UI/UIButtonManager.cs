using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonManager : MonoBehaviour
{
    GameObject player;
    PlayerController controller;

    public void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<PlayerController>();
    }
    public void Update()
    {
        if (controller.isDead)
        {
            controller.inputLeft = false;
            controller.inputRight = false;
            controller.inputJump = false;
        }
    }
    public void LeftButtonDown()
    {
        controller.inputLeft = true;
    }
    public void LeftButtonUp()
    {
        controller.inputLeft = false;
    }
    public void RightButtonDown()
    {
        controller.inputRight = true;
    }
    public void RightButtonUp()
    {
        controller.inputRight = false;
    }
    public void JumpButtonDown()
    {
        controller.inputJump = true;
    }
    public void JumpButtonUp()
    {
        controller.inputJump = false;
    }
}
