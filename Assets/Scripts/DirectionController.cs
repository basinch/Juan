using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionController : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void WalkingUp()
    {
        animator.SetFloat("direction", 0.25f);
    }
    public void WalkingDown()
    {
        animator.SetFloat("direction", 0.50f);
    }

    public void WalkingRight()
    {
        animator.SetFloat("direction", 0.75f);
    }
    public void WalkingLeft()
    {
        animator.SetFloat("direction", 1f);
    }


}
