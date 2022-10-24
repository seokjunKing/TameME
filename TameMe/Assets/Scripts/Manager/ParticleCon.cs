using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCon : MonoBehaviour
{

    public PlayerController playerController;

    public GameObject Blizzard;
    public GameObject Snow;
    
    void Update()
    {
        if (playerController.windTime)
        {
            Snow.SetActive(false);
            Blizzard.SetActive(true);
        }
        else if(!playerController.windTime)
        {
            Blizzard.SetActive(false);
            Snow.SetActive(true);
        }
    }
}
