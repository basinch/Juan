using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float moveSpeed = 5f;
    private Animator animator;
    [SerializeField] private PlayerMovement playerMovement;
    [HideInInspector] public bool isMoving;
    [HideInInspector] public float horseGettingRidden;
    public bool ridingHorse;
    public GameObject closeHorse;
    public HorseScript horseScript;
    public IHorses iHorse;
    public GameObject ismetPoint;
    public AIFlipper aiFlip;
    private bool canInteract;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if(closeHorse != null && !horseScript.isFriend)
            {
                iHorse.BeHappy();
            }
            else if(!ridingHorse && horseScript.isFriend)
            {
                playerMovement.StartRiding();
            }
            else if(ridingHorse)
            {
                playerMovement.StopRiding();
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (closeHorse != null)
            {
                iHorse.BeAngry();
            }
        }
    }
    private void Start()
    {
    }
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
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!ridingHorse)
        {
            Debug.Log("closeHorse updated.");
            closeHorse = col.gameObject;
            iHorse = closeHorse.GetComponent<IHorses>();
            horseScript = closeHorse.GetComponent<HorseScript>();
            aiFlip = closeHorse.GetComponent<AIFlipper>();
            ismetPoint = closeHorse.transform.Find("IsmetPoint")?.gameObject;
        }

    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (!ridingHorse)
        {
            Debug.Log("closeHorse nullified.");
            closeHorse = null;
            iHorse = null;
            aiFlip = null;
            horseScript = null;
            ismetPoint = null;
        }
    }

}
