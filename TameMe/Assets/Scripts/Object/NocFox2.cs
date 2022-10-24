using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NocFox2 : MonoBehaviour
{
    Animator anim;

    public PlayerController Player;

    public Transform target;

    public GameObject Exit;

    [SerializeField] float speed = 0;

    public GameObject Dialogue;
    public GameObject textBox;

    bool isFox = true;
    bool onMove = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isFox)
        {
            if (gameObject.activeSelf)
            {
                isFox = false;
                StartCoroutine(Timer());
            }
        }

        Vector2 Target = target.transform.position;

        if (onMove)
        {
            anim.SetTrigger("Walk");
            transform.position = Vector2.MoveTowards(transform.position, Target, speed);
        }
    }

    public void OnDialogue()
    {
        Dialogue.SetActive(true);
        textBox.SetActive(true);
    }
    public void OffDialogue()
    {
        StartCoroutine(TextBox());
    }

    IEnumerator Timer()
    {
        Player.isControl = false;
        yield return new WaitForSeconds(2f);
        OnDialogue();
    }

    IEnumerator TextBox()
    {
        Dialogue.SetActive(false);
        textBox.SetActive(false);
        yield return new WaitForSeconds(2f);
        onMove = true;
        yield return new WaitForSeconds(3f);
        Exit.SetActive(true);
        Player.isControl = true;

    }
}
