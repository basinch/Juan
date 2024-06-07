using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private PlayerController playerController;
    private IHorses iHorse;
    private HorseScript horseScript;
    public GameObject horseGettingRidden;
    private AIFlipper aiFlipper;

    private bool facingNorth = false;
    private bool facingSouth = true;
    private bool facingWest = false;
    private bool facingEast = false;
    public bool isMoving = false;

    private void Update()
    {
        iHorse = playerController.iHorse;
        horseScript = playerController.horseScript;
        aiFlipper = playerController.aiFlip;
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }

    public void Walk(float moveSpeed)
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
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (movementInput.x < 0)
            {
                facingEast = false;
                facingWest = true;
                transform.eulerAngles = new Vector3(0, 180, 0);
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

        if(horseGettingRidden != null)
        {
            if (movementInput != Vector2.zero)
            {
                aiFlipper.isMoving = true;

                if (movementInput.x > 0)
                {
                    aiFlipper.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (movementInput.x < 0)
                {
                    aiFlipper.transform.eulerAngles = new Vector3(0, 180, 0);
                }
            }
            else
            {
                aiFlipper.isMoving = false;
            }
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
    public void StartRiding()
    {
        animator.SetBool("RidingHorse", true);
        playerController.ridingHorse = true;
        rb2d.position = playerController.ismetPoint.transform.position;
        transform.eulerAngles = new Vector3(0, 0, 0);
        iHorse.StartRiding();
        horseGettingRidden = (iHorse as MonoBehaviour).gameObject;
    }
    public void StopRiding()
    {
        animator.SetBool("RidingHorse", false);
        playerController.ridingHorse = false;
        rb2d.position = playerController.closeHorse.transform.position;
        iHorse.StopRiding();
        horseGettingRidden = null;
    }
}