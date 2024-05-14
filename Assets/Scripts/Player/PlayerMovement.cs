using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    public float moveSpeed = 5f;
    public Animator animator;

    private bool facingNorth = false;
    private bool facingSouth = false;
    private bool facingWest = false;
    private bool facingEast = false;
    public bool isMoving = false;

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 movementInput = new Vector2(horizontalInput, verticalInput).normalized;

        if (movementInput != Vector2.zero)
        {
            isMoving = true;

            if (movementInput.x > 0)
            {
                facingEast = true;
                facingWest = false;
            }
            else if (movementInput.x < 0)
            {
                facingEast = false;
                facingWest = true;
            }
            else
            {
                facingEast = false;
                facingWest = false;
            }

            if (movementInput.y > 0)
            {
                facingNorth = true;
                facingSouth = false;
            }
            else if (movementInput.y < 0)
            {
                facingNorth = false;
                facingSouth = true;
            }
            else
            {
                facingNorth = false;
                facingSouth = false;
            }
        }
        else
        {
            isMoving = false;
        }

        animator.SetFloat("Horizontal", movementInput.x);
        animator.SetFloat("Vertical", movementInput.y);
        animator.SetFloat("Speed", movementInput.magnitude);

        animator.SetBool("FacingNorth", facingNorth);
        animator.SetBool("FacingSouth", facingSouth);
        animator.SetBool("FacingWest", facingWest);
        animator.SetBool("FacingEast", facingEast);

        rb2d.MovePosition(rb2d.position + movementInput * moveSpeed * Time.fixedDeltaTime);
    }
}