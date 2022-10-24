using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    //public Animator anim;

    public RealBird bird;

    [SerializeField] public float moveMax = -10f;
    [SerializeField] public float moveMin = -12.0f;
    [SerializeField] public float moveSpeed = 30;

    [SerializeField] float movePower = 0.12f;

    public Nest nest;

    public bool upmod = false;

    //bool isMax = false;
    void Start()
    {
        
    }
    void Update()
    {
        if (upmod)
        {
            MoveUp();
        }
        else
        {
            MoveDown();
        }
    }

    void MoveDown()
    {
        Vector3 pos = this.transform.position;

        Vector3 moveVelocity = Vector3.zero;

        if (nest.isTrigger && pos.y > moveMin)
        {
            moveVelocity = new Vector3(0, -movePower, 0);
        }
        else if (!nest.isTrigger && pos.y < moveMax)
        {
            moveVelocity = new Vector3(0, movePower, 0);
        }
        

        transform.position += moveVelocity * moveSpeed * Time.deltaTime;


        if(pos.y > moveMin)
        {
            bird.fly = true;
        }
        else if(pos.y <= moveMin)
        {
            bird.fly = false;
        }
    }

    void MoveUp()
    {
        Vector3 pos = this.transform.position;

        Vector3 moveVelocity = Vector3.zero;

        if (nest.isTrigger && pos.y < moveMax)
        {
            moveVelocity = new Vector3(0, movePower, 0);
        }
        else if (!nest.isTrigger && pos.y > moveMin)
        {
            moveVelocity = new Vector3(0, -movePower, 0);
        }


        transform.position += moveVelocity * moveSpeed * Time.deltaTime;

        if (pos.y > moveMin)
        {
            bird.fly = true;
        }
        else if (pos.y <= moveMin)
        {
            bird.fly = false;
        }
    }
}
