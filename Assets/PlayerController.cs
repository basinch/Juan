using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    Vector2 movement;
    public float moveSpeed = 5f;
    public Animator animator;
    public bool ridingHorse = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ridingHorse)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }


    }
    void FixedUpdate()
    {
        if (!ridingHorse)
        {
            rb2d.MovePosition((rb2d.position + movement * moveSpeed * Time.fixedDeltaTime));
        }
    }

}
