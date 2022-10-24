using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float setTime = 10;
    public float maxTime = 10;

    SpriteRenderer sr;

    Animator anim;

    public Transform rayPoint;

    [SerializeField] bool isWall = false;
    [SerializeField] bool isPlayer = false;

    public Transform spawnPoint;

    public PlayerController player;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.speed = 0.5f;
    }
    void Update()
    {
        BreakTimer();

        if (player.isDead)
        {
            transform.position = spawnPoint.position;
        }
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(rayPoint.position, Vector3.right, new Color(1, 0, 0));
        RaycastHit2D rayEgg = Physics2D.Raycast(rayPoint.position, Vector3.right, 1, LayerMask.GetMask("Player"));
        if (rayEgg.collider != null)
        {
            if (rayEgg.distance < 0.5f)
            {
                isPlayer = true;
                anim.SetBool("onMove", true);
            }
            else
            {
                setTime = maxTime;
                isPlayer = false;
                anim.SetBool("onMove", false);
            }
        }
        Debug.DrawRay(rayPoint.position, Vector3.left, new Color(1, 0, 0));
        RaycastHit2D rayEggL = Physics2D.Raycast(rayPoint.position, Vector3.left, 1, LayerMask.GetMask("Player"));
        if (rayEggL.collider != null)
        {
            if (rayEggL.distance < 0.5f)
            {
                isPlayer = true;
                anim.SetBool("onMove", true);
            }
            else
            {
                isPlayer = false;
                anim.SetBool("onMove", false);
                setTime = maxTime;
            }
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destroy"))
        { 
            StartCoroutine(delayTime());
        }

        if (collision.gameObject.CompareTag("Bird"))
        {
            StartCoroutine(delayTime());
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            isWall = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            isWall = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayer = false;
            anim.SetBool("onMove", false);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            isWall = false;
        }
    }

    void BreakTimer()
    {
        if (isWall && isPlayer)
        {
            setTime -= Time.deltaTime;

            if(setTime <= 0)
            {
                StartCoroutine(delayTime());
                setTime = maxTime;
            }
        }
        else
        {
            setTime = maxTime;
        }
    }

    IEnumerator delayTime()
    {
        Debug.Log("dd");
        anim.SetBool("onMove", false);
        anim.SetTrigger("Break");
        float fadeCount = 1;
        while (fadeCount > 0)
        {
            fadeCount -= 0.05f;
            yield return new WaitForSeconds(0.01f);
            sr.color = new Color(1, 1, 1, fadeCount);
        }
        transform.position = spawnPoint.position;
        anim.SetBool("onMove", false);
        yield return new WaitForSeconds(1f);
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.05f;
            yield return new WaitForSeconds(0.01f);
            sr.color = new Color(1, 1, 1, fadeCount);
        }      
        anim.SetTrigger("Spawn");
        isWall = false;
    }
}