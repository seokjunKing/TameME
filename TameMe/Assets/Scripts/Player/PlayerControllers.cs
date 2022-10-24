using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControllers : MonoBehaviour
{
    public bool isControl = false;
    public bool _isLadder = false;
    public bool _isLever = false;
    public bool LeverUp = false;

    public bool _onSaveP1 = false;
    public bool _onSaveP2 = false;


    //public GameObject Circle;

    public FadeInOut fade;
    public Transform[] spawnPoint;

    int num_Scene;

    [Header("Walk")]
    public float walkSpeed = 4;

    [Header("Jump")]
    public Transform jump_Pos;
    public float checkRadius;
    public float jumpPower = 1;
    public LayerMask isTile;
    private bool isGround;


    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    public GameController2 GameController;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        num_Scene = SceneManager.GetActiveScene().buildIndex;
    }
    void Start()
    {
        DataManager.instance.nowPlayer.stageNum = num_Scene;
        DataManager.instance.SaveData();
    }

    void Update()
    {
        Lever();

        if (GameController.pChange)
        {
            isControl = true;
        }
        else
        {
            isControl = false;
        }
    }

    void FixedUpdate()
    {
        if (isControl)
        {
            rigid.gravityScale = 3;
            Move();
            isGround = Physics2D.OverlapCircle(jump_Pos.position, checkRadius, isTile);
            //animator.speed = 1;

            Jump();
        }
        else
        {
            rigid.velocity = Vector2.zero;
            rigid.gravityScale = 0;
        }
    }
    void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        rigid.velocity = (new Vector2((hor) * walkSpeed * Time.deltaTime, rigid.velocity.y));

        if (hor > 0)
        {
            transform.localScale = new Vector3(0.125f, 0.125f, 0);
            //animator.SetBool("walk", true);
        }
        else if (hor < 0)
        {
            transform.localScale = new Vector3(-0.125f, 0.125f, 0);
            //animator.SetBool("walk", true);
        }
        else
        {
            //animator.SetBool("walk", false);
        }
    }
    void Jump()
    {
        if (isGround == true)
        {
            if (Input.GetAxis("Jump") != 0)
            {
                rigid.velocity = Vector2.up * jumpPower;
            }
        }
    }
    void Lever()
    {
        if (_isLever)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (LeverUp)
                {
                    LeverUp = false;
                }
                else
                {
                    LeverUp = true;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Destroy"))
        {
            if (_onSaveP1)
            {
                fade.FadeIn();
                Time.timeScale = 0f;
                StartCoroutine(delayTime(4f));
                Time.timeScale = 1f;
                transform.position = spawnPoint[0].transform.position;
            }
            else if (_onSaveP2)
            {
                transform.position = spawnPoint[1].transform.position;
            }
            else { SceneManager.LoadScene(num_Scene); }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("saveP"))
        {

            if (_onSaveP1)
            {
                _onSaveP2 = true;
                _onSaveP1 = false;
            }
            else
            {
                _onSaveP1 = true;
            }
        }

        if (collision.gameObject.CompareTag("NPC"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 0f;
                //_NPC = true;
            }
        }

        if (collision.gameObject.CompareTag("Ladder"))
        {
            _isLadder = true;
        }

        if (collision.gameObject.CompareTag("Lever"))
        {
            _isLever = true;
        }

        if (collision.gameObject.CompareTag("Trap"))
        {
            // Circle.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            _isLadder = false;
        }

        if (collision.gameObject.CompareTag("Lever"))
        {
            _isLever = false;
        }
    }
    IEnumerator delayTime(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

    }
}
