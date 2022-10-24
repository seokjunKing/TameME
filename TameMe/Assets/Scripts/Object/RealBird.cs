using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealBird : MonoBehaviour
{
    Animator anim;

    public bool fly = true;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (fly)
        {
            anim.SetBool("Fly", true);
        }
        else
        {
            anim.SetBool("Fly", false);
        }
    }
}
