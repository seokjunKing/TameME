using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nest : MonoBehaviour
{
    public bool isTrigger = false;

    //public GameObject Egg;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Open"))
        {
            isTrigger = true;
        }
        else
        {
            //isTrigger = false;
        }
        //else if (collider.gameObject.CompareTag("Open"))
        //{
        //    isTrigger = true;
        //}
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Open"))
        {
            isTrigger = false;
        }
    }
}
