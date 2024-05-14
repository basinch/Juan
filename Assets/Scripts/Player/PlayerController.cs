using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    public float moveSpeed = 5f;
    private Animator animator;
    [SerializeField] private PlayerMovement playerMovement;
    [HideInInspector] public bool isMoving;
    [HideInInspector] public float horseGettingRidden;

    private void Awake()
    {
        SyncVariables();
    }
    private void Update()
    {
        SyncVariables();
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 movementInput = new Vector2(horizontalInput, verticalInput).normalized;

        animator.SetFloat("Horizontal", movementInput.x);
        animator.SetFloat("Vertical", movementInput.y);
        animator.SetFloat("Speed", movementInput.magnitude);

        rb2d.MovePosition(rb2d.position + movementInput * moveSpeed * Time.deltaTime);
    }
    private void SyncVariables()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        isMoving = playerMovement.isMoving;
    }
}
