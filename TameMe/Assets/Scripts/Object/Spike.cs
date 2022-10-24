using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] float moveTimer = 3f;

    [SerializeField] float moveMax = -10f;
    [SerializeField] float moveMin = -12.0f;
    [SerializeField] float moveSpeed = 30;

    [SerializeField] float movePower = 0.12f;

    bool up = false;

    public bool checkUp = false;

    void Start()
    {
        StartCoroutine(onTimer());
    }
    void Update()
    {
        if (checkUp)
        {
            Move2();
        }
        else
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 pos = this.transform.position;

        Vector3 moveVelocity = Vector3.zero;

        if (!up && pos.y > moveMin)
        {
            moveVelocity = new Vector3(0, -movePower, 0);
        }
        else if (up && pos.y < moveMax)
        {
            moveVelocity = new Vector3(0, movePower, 0);
        }


        transform.position += moveVelocity * moveSpeed * Time.deltaTime;
    }
    void Move2()
    {
        Vector3 pos = this.transform.position;

        Vector3 moveVelocity = Vector3.zero;

        if (!up && pos.y < moveMax)
        {
            moveVelocity = new Vector3(0, movePower, 0);
        }
        else if (up && pos.y > moveMin)
        {
            moveVelocity = new Vector3(0, -movePower, 0);
        }


        transform.position += moveVelocity * moveSpeed * Time.deltaTime;
    }


    IEnumerator onTimer()
    {
        if (up)
        {
            up = false;
        }
        else
        {
            up = true;
        }

        yield return new WaitForSeconds(moveTimer);
        StartCoroutine(onTimer());
    }
}
