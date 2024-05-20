using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFlipper : MonoBehaviour
{
    private AIPath aiPath;
    [HideInInspector] public Animator animator;
    public bool isMoving = false;
    public GameObject spriteObject;
    private HorseScript horseScript;

    private void Awake()
    {
        animator = spriteObject.GetComponent<Animator>();
        aiPath = GetComponent<AIPath>();
        horseScript = GetComponent<HorseScript>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!horseScript.isGetiingRidden)
        {
            if (aiPath.desiredVelocity.magnitude > 0.01f)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }


        if (horseScript.isGetiingRidden)
        {
            if (aiPath.desiredVelocity.x >= 0.01f)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (aiPath.desiredVelocity.x <= -0.01f)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else
        {
            if (aiPath.desiredVelocity.x >= 0.01f)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (aiPath.desiredVelocity.x <= -0.01f)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }


        animator.SetBool("IsMoving", isMoving);
    }
}
