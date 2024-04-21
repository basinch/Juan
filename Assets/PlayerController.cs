using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject beyazid;
    public GameObject donkey;
    public GameObject gulpembe;
    public GameObject twig;
    public GameObject juan;
    private GameObject horseGettingRidden;

    public Image appleIcon;
    public Image brushIcon;
    public Image whipIcon;
    public Image carrotIcon;


    [SerializeField] private Rigidbody2D rb2d;
    public PlayerInventory inv;
    Vector2 movement;
    public float moveSpeed = 5f;
    public Animator animator;
    public bool ridingHorse = false;
    public bool isMoving = false;

    private GameObject collidedObject;
    private bool isColliding = false;
    public string objectTag;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (collidedObject != null)
            {
                if (collidedObject.CompareTag("Beyazid") && inv.selectedItem == 1 && isColliding)
                {
                    inv.hasApple = false;
                    appleIcon.color = Color.black;
                    inv.selectedItem = 0;
                    inv.selectedItem = 0;
                    inv.NewItemSelected();
                }
                else if (collidedObject.CompareTag("Donkey") && inv.selectedItem == 2 && isColliding)
                {
                    inv.hasCarrot = false;
                    carrotIcon.color = Color.black;
                    inv.selectedItem = 0;
                    inv.selectedItem = 0;
                    inv.NewItemSelected();
                }
                else if (collidedObject.CompareTag("Gulpembe") && inv.selectedItem == 3 && isColliding)
                {
                    inv.hasBrush = false;
                    brushIcon.color = Color.black;
                    inv.selectedItem = 0;
                    inv.selectedItem = 0;
                    inv.NewItemSelected();
                }
                else if (collidedObject.CompareTag("Juan") && inv.selectedItem == 4 && isColliding)
                {
                    inv.hasWhip = false;
                    whipIcon.color = Color.black;
                    inv.selectedItem = 0;
                    inv.NewItemSelected();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(collidedObject != null)
            {
                if (collidedObject.CompareTag("Beyazid") && !inv.hasApple && isColliding)
                {

                    StartRiding();
                }
                else if (collidedObject.CompareTag("Donkey") && !inv.hasCarrot && isColliding)
                {

                    StartRiding();
                }
                else if (collidedObject.CompareTag("Gulpembe") && !inv.hasBrush && isColliding)
                {

                    StartRiding();
                }
                else if (collidedObject.CompareTag("Juan") && !inv.hasWhip && isColliding)
                {

                    StartRiding();
                }
            }

            if (horseGettingRidden != null)
            {
                StopRidingHorse();
            }
        }

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

            if (inv.selectedItem > 0)
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

    private void StartRiding()
    {       
        if (collidedObject.CompareTag("Beyazid") && !inv.hasApple)
        {
            objectTag = "Beyazid";
            Destroy(collidedObject);
            animator.SetBool(objectTag, true);
        }
        else if (collidedObject.CompareTag("Donkey") && !inv.hasCarrot)
        {
            objectTag = "Donkey";
            Destroy(collidedObject);
            animator.SetBool(objectTag, true);
        }
        else if (collidedObject.CompareTag("Gulpembe") && !inv.hasBrush)
        {
            objectTag = "Gulpembe";
            Destroy(collidedObject);
            animator.SetBool(objectTag, true);
        }
        else if (collidedObject.CompareTag("Juan") && !inv.hasWhip)
        {
            objectTag = "Juan";
            Destroy(collidedObject);
            animator.SetBool(objectTag, true);
        }
        else if (collidedObject.CompareTag("twig"))
        {
            objectTag = "twig";
            Destroy(collidedObject);
            animator.SetBool(objectTag, true);
        }
        
        if(objectTag != null)
        {
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
        }
    }

    private void StopRidingHorse()
    {
        Instantiate(horseGettingRidden, transform.position, transform.rotation);
        horseGettingRidden = null;
        animator.SetBool(objectTag, false);
        objectTag = null;
    }

}
