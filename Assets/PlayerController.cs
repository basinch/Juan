using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject beyazid;
    public GameObject donkey;
    public GameObject gulpembe;
    public GameObject twig;
    public GameObject juan;
    private GameObject horseGettingRidden;

    [SerializeField] private Rigidbody2D rb2d;
    public PlayerInventory playerInventory;
    Vector2 movement;
    public float moveSpeed = 5f;
    public Animator animator;
    public bool ridingHorse = false;
    public bool isMoving = false;

    private GameObject collidedObject;
    private bool isColliding = false;
    private bool isObjectVisible = true;
    public string objectTag;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (horseGettingRidden != null)
            {
                ShowObject();
            }
            else if (isColliding)
            {
                HideObject();
            }
        }


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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Beyazid") || collision.CompareTag("Donkey") || collision.CompareTag("Gulpembe") || collision.CompareTag("Juan") || collision.CompareTag("twig"))
        {
            isColliding = true;
            collidedObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Beyazid") || collision.CompareTag("Donkey") || collision.CompareTag("Gulpembe") || collision.CompareTag("Juan") || collision.CompareTag("twig"))
        {
            isColliding = false;
            collidedObject = null;
        }
    }

    private void HideObject()
    {       
        if (collidedObject.CompareTag("Beyazid"))
        {
            objectTag = "Beyazid";
        }
        else if (collidedObject.CompareTag("Donkey"))
        {
            objectTag = "Donkey";
        }
        else if (collidedObject.CompareTag("Gulpembe"))
        {
            objectTag = "Gulpembe";
        }
        else if (collidedObject.CompareTag("Juan"))
        {
            objectTag = "Juan";
        }
        else if (collidedObject.CompareTag("twig"))
        {
            objectTag = "twig";
        }
        switch (objectTag)
        {
            case ("Beyazid"):
                horseGettingRidden = beyazid;
                break;
            case ("Donkey"):
                horseGettingRidden = donkey;
                break;
            case ("Gulpembe"):
                horseGettingRidden = gulpembe;
                break;
            case ("Juan"):
                horseGettingRidden = juan;
                break;
            case ("twig"):
                horseGettingRidden = twig;
                break;
        }
        Destroy(collidedObject);
        animator.SetBool(objectTag, true);
    }

    private void ShowObject()
    {
        Instantiate(horseGettingRidden, transform.position, transform.rotation);
        horseGettingRidden = null;
        animator.SetBool(objectTag, false);

    }

}
