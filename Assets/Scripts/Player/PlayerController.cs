using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float moveSpeed = 5f;
    private Animator animator;
    [SerializeField] private PlayerMovement playerMovement;
    [HideInInspector] public bool isMoving;
    [HideInInspector] public float horseGettingRidden;

    private void Awake()
    {
        SyncVariables();
    }
    private void FixedUpdate()
    {
        playerMovement.Walk(moveSpeed);
    }
    private void SyncVariables()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        isMoving = playerMovement.isMoving;
        rb2d = GetComponent<Rigidbody2D>();
    }
}
