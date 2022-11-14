using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movePower = 1f;
    public float moveTimer = 5f;

    Animator anim;

    int movementFlag = 0;

    GameObject traceTarget;

    bool isTracing = false;

    [SerializeField] public float speed = 1.0f;

    public bool idle = false;
    public bool onBlue = false;
    


    public PlayerController player;
    public Transform spawnPoint;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(ChangeMovement());
    }

    void Update()
    {
        if (player.isDead)
        {
            transform.position = spawnPoint.transform.position;
            
            onBlue = false;
        }
    }

    void FixedUpdate()
    {
        Vector3 moveVelocity = Vector3.zero;
        string dist = "";

        if (onBlue)
        {
            anim.SetBool("onSlide", true);
            Vector3 dir = transform.localScale;

            dir.y = 0f;
            dir.z = 0f;

            if(dir.x == 0.3f)
            {
                transform.position += 3f * speed * movePower * Time.deltaTime * -dir;
            }
            else if(dir.x == -0.3f)
            {
                transform.position += 3f * speed * movePower * Time.deltaTime * -dir;
            }

        }
        else
        {
            if (idle)
            {
                

                if (isTracing)
                {
                    Vector3 playerPos = traceTarget.transform.position;

                    if (playerPos.x < transform.position.x)
                    {
                        dist = "Left";
                    }
                    else if (playerPos.x > transform.position.x)
                    {
                        dist = "Right";
                    }

                    anim.SetBool("onRun", true);
                }
                else
                {
                    anim.SetBool("onRun", false);
                }

                if (dist == "Left")
                {
                    moveVelocity = Vector3.left;
                    transform.localScale = new Vector3(0.3f, 0.3f, 1);
                    //isRight = false;
                }
                else if (dist == "Right")
                {
                    moveVelocity = Vector3.right;
                    transform.localScale = new Vector3(-0.3f, 0.3f, 1);
                    //isRight = true;
                }

                transform.position += moveVelocity * 1.5f * movePower * Time.deltaTime;
                
            }
            else
            {
                Move();
            }
        }
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        string dist = "";

        if (isTracing)
        {
            Vector3 playerPos = traceTarget.transform.position;

            if(playerPos.x < transform.position.x)
            {
                dist = "Left";
            }
            else if(playerPos.x > transform.position.x)
            {
                dist = "Right";
            }

            if (dist == "Left")
            {
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(0.3f, 0.3f, 1);
                //isRight = false;
            }
            else if (dist == "Right")
            {
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(-0.3f, 0.3f, 1);
                //isRight = true;
            }

            transform.position += moveVelocity * 1.5f * movePower * Time.deltaTime;
            anim.SetBool("onMove", false);
            anim.SetBool("onRun", true);
        }
        else
        {
            if(movementFlag == 1)
            {
                dist = "Left";
            }
            else if (movementFlag == 2)
            {
                dist = "Right";
            }


            if (dist == "Left")
            {
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(0.3f, 0.3f, 1);
                //isRight = false;
            }
            else if (dist == "Right")
            {
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(-0.3f, 0.3f, 1);
                //isRight = true;
            }

            transform.position += moveVelocity * movePower * Time.deltaTime;
            anim.SetBool("onMove", true);
            anim.SetBool("onRun", false);
        }



        
    }
  
    IEnumerator ChangeMovement()
    {
        //movementFlag = Random.Range(0, 3);
        if(movementFlag == 0)
        {
            movementFlag = 1;
        }
        else if(movementFlag == 1)
        {
            movementFlag = 2;
        }
        else if(movementFlag == 2)
        {
            movementFlag = 1;
        }


        //Debug.Log(movementFlag);
        yield return new WaitForSeconds(moveTimer);
        StartCoroutine(ChangeMovement());
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Blue"))
        {
            onBlue = true;
        }

        if (collision.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Blue"))
        {
            onBlue = false;
            anim.SetBool("onSlide", false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            traceTarget = collision.gameObject;

            StopAllCoroutines();
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTracing = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTracing = false;

            StartCoroutine(ChangeMovement());
        }
    }
}
