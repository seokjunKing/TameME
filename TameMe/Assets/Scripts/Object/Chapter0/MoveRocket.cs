using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRocket : MonoBehaviour
{
    public Transform point1;
    public Transform point2;

    public FadeInOut fade;

    [SerializeField] float speed = 0.1f;

    bool trig1 = false;
    bool trig2 = false;

    Vector3 vel = Vector3.zero;

    void Start()
    {
        StartCoroutine(Move1());
    }

    void Update()
    {
        if(trig1)
        {
            transform.position = Vector3.MoveTowards(transform.position, point1.transform.position, speed);
        }

        if (trig2)
        {
            transform.position = Vector3.MoveTowards(transform.position, point2.transform.position, speed * 2);
        }
    }

    IEnumerator Move1()
    {
        trig1 = true;
        yield return new WaitForSeconds(3f);
        trig1 = false;
        trig2 = true;
        yield return new WaitForSeconds(1.5f);
        fade.OnClickFade();
    }

}
