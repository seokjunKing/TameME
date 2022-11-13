using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Save2 : MonoBehaviour
{
    public PlayerControllers player;
    public FoxController fox;

    Animator anim;

    // SavePoint check
    public bool is_sp1 = false;
    public bool is_sp2 = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        SavePoint();
    }

    void SavePoint()
    {
        if (player._onSaveP1 && fox._onSaveP1)
        {
            is_sp1 = true;
            anim.SetTrigger("Save");
        }
        if (player._onSaveP2 && fox._onSaveP2)
        {
            is_sp1 = false;
            is_sp2 = true;
            anim.SetTrigger("Save");
        }
    }
}
