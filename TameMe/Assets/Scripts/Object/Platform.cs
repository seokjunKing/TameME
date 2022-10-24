using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] public float moveMax = 10f;
    [SerializeField] public float moveMin = 2f;
    
    [SerializeField] public float moveSpeed = 20f;
    [SerializeField] public float movePower = 0.12f;

    public FoxController FoxController;
    //public PlayerControllers playerControllers;
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 pos = this.transform.position;

        Vector3 moveVelocity = Vector3.zero;

        if (FoxController.LeverUp && pos.y < moveMax)
        {
            moveVelocity = new Vector3(0, movePower, 0);
        }
        else if(!FoxController.LeverUp && pos.y > moveMin)
        {
            moveVelocity = new Vector3(0, -movePower, 0);
        }
        transform.position += moveVelocity * moveSpeed * Time.deltaTime;
    }
}
