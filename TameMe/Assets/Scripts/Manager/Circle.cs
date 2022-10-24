using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    SpriteRenderer sprite;
    Vector2 direction;

    public float moveSpeed = 0.01f;
    public float minSize = 0.3f;
    public float maxSize = 0.7f;
    public float sizeSpeed = 1;
    //public Color[] colors;
    public float colorSpeed = 5;
    float timer = 0;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        direction = new Vector2(Random.Range(-1.0f,1.0f), Random.Range(-1.0f,1.0f));
        float size = Random.Range(minSize,maxSize);
        transform.localScale = new Vector2(size, size);
        //sprite.color = colors[Random.Range(0, colors.Length)];
    }
    void Update()
    {
        transform.Translate(direction * moveSpeed);
        transform.localScale = Vector2.Lerp(transform.localScale, Vector2.zero, Time.deltaTime * sizeSpeed);

        Color color = sprite.color;
        color.a = Mathf.Lerp(sprite.color.a, 0 , Time.deltaTime * colorSpeed);
        sprite.color = color;

        if (timer >= 1f)
        {
            Destroy(gameObject);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
