using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Save : MonoBehaviour
{
    public PlayerController player;

    Animator anim;

    [SerializeField] private bool Check1 = false;
    [SerializeField] private bool Check2 = false;

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
        if (Check1)
        {
            if (player._onSaveP1)
            {
                anim.SetBool("Save1", true);
            }
        }

        if (Check2)
        {
            if (player._onSaveP2)
            {
                anim.SetBool("Save2", true);
            }
        }
    }
}
