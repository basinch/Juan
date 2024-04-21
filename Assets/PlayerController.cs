using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    public PlayerInventory playerInventory;
    Vector2 movement;
    public float moveSpeed = 5f;
    public Animator animator;
    public bool ridingHorse = false;
    public bool isMoving = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(animator.GetFloat("Speed"));
        if (animator.GetFloat("Speed") > 0)
        {
            isMoving = true;
        }
        else if(animator.GetFloat("Speed") == 0)
        {
            isMoving = false;
        }
        if (!ridingHorse)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

            if (playerInventory.selectedItem > 0)
            {
                animator.SetBool("Holding", true);
            }
            else
            {
                animator.SetBool("Holding", false);
            }
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
