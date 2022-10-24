using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator anim;

    public Transform rayPoint;

    public float animSpeed = 1f;

    public bool _onSaveP1 = false;
    public bool _onSaveP2 = false;

    public bool _NPC = false;

    public bool _isLadder = false;
    public bool _isLever = false;

    public bool LeverUp = true;

    public bool _isPull = false;

    public bool _onBlue = false;

    public bool _isWind = false;
    public bool windTime = false;

    public bool isDead = false;

    bool _onJump;

    int num_Scene;

    public bool isControl = true;

    public LayerMask whatisPlatform;

    [SerializeField]
    public float _moveSpeed = 2.0f;
    public float _realMoveSpeed = 2.0f;
    public float _JumpForce = 8.0f;
    private float _realJumpForce = 8.0f;

    public GameController gameController;
    public FadeInOut fade;
    public Transform[] spawnPoint;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        num_Scene = SceneManager.GetActiveScene().buildIndex;
    }

    void Start()
    {
        DataManager.instance.nowPlayer.stageNum = num_Scene;
        DataManager.instance.SaveData();
    }

    void Update()
    {
        if (isControl)
        {
            Jump();
            Spawn();
            //Lever();
        }
        else
        {
            anim.SetBool("onWalk", false);
            anim.SetBool("onSlide", false);
            anim.SetBool("onPush", false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_onSaveP1)
            {
                StartCoroutine(Reborn(0.5f));
            }
            else if (_onSaveP2)
            {
                StartCoroutine(Reborn2(0.5f));
            }
            else { SceneManager.LoadScene(num_Scene); }
        }

        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rayPoint.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rayPoint.position, Vector3.down, 0.5f, whatisPlatform);
            if (rayHit.collider != null)
            {
                if (rayHit.collider.gameObject.CompareTag("Blue"))
                {
                    _onBlue = true;
                }
                else
                {
                    _onBlue = false;
                }
            }
        }

    }

    void FixedUpdate()
    {
        if (isControl)
        {
            Move();
        }

        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rayPoint.position, Vector3.down * 0.5f, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rayPoint.position, Vector3.down, 0.5f, LayerMask.GetMask("Platform"));
            if (rayHit.collider != null)
            {

                if (rayHit.distance < 0.5f)
                {
                    JumpCooltime();
                }
            }
        }

        Debug.DrawRay(rayPoint.position, Vector3.right * transform.localScale.x, new Color(1, 0, 0));
        RaycastHit2D rayEgg = Physics2D.Raycast(rayPoint.position, Vector3.right * transform.localScale.x, 0.5f, LayerMask.GetMask("Egg"));
        if (rayEgg.collider != null)
        {
            if(rayEgg.distance < 0.4f)
            {
                anim.SetBool("onPush", true);
            }
        }
        else
        {
            anim.SetBool("onPush", false);
        }
    }

    void Move()
    {
        
        float x = Input.GetAxis("Horizontal"); // 수평 축 이동, 오른족 x 1 왼쪽 -1 기본 0
        rigid.velocity = (new Vector2((x) * _realMoveSpeed * Time.deltaTime, rigid.velocity.y));

        if (x > 0)
        {
            anim.speed = animSpeed;
            anim.SetBool("onWalk", true);
            transform.localScale = new Vector3(0.125f, 0.125f, 1);
        }
        else if (x < 0)
        {
            anim.speed = animSpeed;
            anim.SetBool("onWalk", true);
            transform.localScale = new Vector3(-0.125f, 0.125f, 1);
        }
        else
        {
            anim.speed = animSpeed * 0.5f;
            anim.SetBool("onWalk", false);
        }
        //Vector2 moveVec = new Vector2(x, 0); // 객체의 포지션 값을 변경하는 API
        //transform.Translate(moveVec * _realMoveSpeed * Time.deltaTime);

        if (_onBlue)
        {
            anim.speed = animSpeed * 0.5f;
            _realMoveSpeed = 2f * _moveSpeed;
            anim.SetBool("onSlide", true);
        }
        else
        {
            anim.speed = animSpeed;
            _realMoveSpeed = _moveSpeed;
            anim.SetBool("onSlide", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !_onJump)
        {
            rigid.AddForce(Vector2.up * _realJumpForce, ForceMode2D.Impulse);

            if (_onJump)
            {

            }
            else
            {
                _onJump = true;
            }
            
        }

    }
    void JumpCooltime()
    {
        _onJump = false;
        _isPull = false;
    }

    void Spawn()
    {
        if(transform.position.y < -50)
        {
            if (_onSaveP1)
            {
                
                StartCoroutine(Reborn(0.5f));
            }
            else if (_onSaveP2)
            {
                StartCoroutine(Reborn2(0.5f));
            }
            else { SceneManager.LoadScene(num_Scene); }
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
                StartCoroutine(Reborn(0.5f));
                
            }
            else if (_onSaveP2)
            {
                StartCoroutine(Reborn2(0.5f));
            }
            else { SceneManager.LoadScene(num_Scene); }
        }

        if (collision.gameObject.CompareTag("Rose"))
        {
            anim.SetBool("onWalk", false);
        }
    }
    

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Open"))
        {
            anim.SetBool("onPush", false);
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        
        //if (collision.gameObject.CompareTag("Blue"))
        //{
        //    _onBlue = true;
        //}
        //else
        //{
        //    _onBlue = false;
        //}
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("saveP1"))
        {
            if (!_onSaveP2)
            {
                _onSaveP1 = true;
            }
        }

        if (collision.gameObject.CompareTag("saveP2"))
        {
            _onSaveP1 = false;
            _onSaveP2 = true;
        }

        if (collision.gameObject.CompareTag("NPC"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                isControl = false;
                _NPC = true;
            }
        }

        if (collision.gameObject.CompareTag("NextScene"))
        {
            gameController.OnClickNextScene();
        }

        //if (collision.gameObject.CompareTag("Ladder"))
        //{
        //    _isLadder = true;
        //}

        //if (collision.gameObject.CompareTag("Lever"))
        //{
        //    _isLever = true;
        //}

        //if (collision.gameObject.CompareTag("Trap"))
        //{
        //    Circle.SetActive(true);
        //}

        if (collision.gameObject.CompareTag("Wind"))
        {
            _isWind = true;
            StartCoroutine(WindTimer(3f));
        }

        if (collision.gameObject.CompareTag("Potion"))
        {
            isControl = false;
            anim.SetBool("onWalk", false);
            gameController.potion();
            collision.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wind"))
        {
            if (windTime)
            {
                rigid.AddForce(-Vector2.right * 5000 * Time.deltaTime);
            }
            else
            {

            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Ladder"))
        //{
        //    _isLadder = false;
        //}

        //if (collision.gameObject.CompareTag("Lever"))
        //{
        //    _isLever = false;
        //}

        if (collision.gameObject.CompareTag("Wind"))
        {
            _isWind = false;
            //StopCoroutine(WindTimer(3f));
        }
    }

    IEnumerator Reborn(float delayTime)
    {
        isControl = false;
        gameObject.layer = 10;
        //anim.SetBool(Dead, true);
        yield return new WaitForSeconds(delayTime);
        //anim.SetBool(Dead, false);
        isDead = true;
        fade.FadeOut();
        yield return new WaitForSeconds(delayTime);
        transform.position = spawnPoint[0].transform.position;
        isDead = false;
        gameObject.layer = 9;
        isControl = true;
    }
    IEnumerator Reborn2(float delayTime)
    {
        isControl = false;
        gameObject.layer = 10;
        //anim.SetBool(Dead, true);
        yield return new WaitForSeconds(delayTime);
        //anim.SetBool(Dead, false);
        isDead = true;
        fade.FadeOut();
        yield return new WaitForSeconds(delayTime);
        transform.position = spawnPoint[1].transform.position;
        isDead = false;
        gameObject.layer = 9;
        isControl = true;
    }

    IEnumerator WindTimer(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        
        if (_isWind)
        {
            if (windTime)
            {
                windTime = false;
            }
            else
            {
                windTime = true;
            }
            StartCoroutine(WindTimer(3f));
        }
        else
        {
            windTime = false;
        }
    }
}