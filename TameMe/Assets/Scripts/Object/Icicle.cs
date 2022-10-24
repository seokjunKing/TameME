using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{
    private ParticleSystem particle;
    private SpriteRenderer sr;
    private BoxCollider2D bc;

    private bool check = false;

    private void Update()
    {
        if (!check)
        {
            check = true;
            particle = GetComponentInChildren<ParticleSystem>();
            sr = GetComponent<SpriteRenderer>();
            bc = GetComponent<BoxCollider2D>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Break());
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(Break());
        }
    }

    private IEnumerator Break()
    {
        particle.Play();

        sr.enabled = false;
        bc.enabled = false;

        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);

        Destroy(gameObject);
    }
}
