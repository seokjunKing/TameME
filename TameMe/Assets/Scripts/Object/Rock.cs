using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public bool isBlue = false;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isBlue == true)
        {
            
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Blue"))
        {
            isBlue = true;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {

        }
        else
        {
            isBlue = false;
        }
    }

}
