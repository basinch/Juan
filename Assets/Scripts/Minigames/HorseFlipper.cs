using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseFlipper : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.flipX = true;
    }
}
