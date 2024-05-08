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
    public GameObject horseGettingRidden;

    public Image appleIcon;
    public Image brushIcon;
    public Image whipIcon;
    public Image carrotIcon;

    [SerializeField] private Rigidbody2D rb2d;
    public PlayerInventory inv;
    Vector2 movement;
    public float moveSpeed = 5f;
    public Animator animator;
    public bool isMoving = false;

    private GameObject collidedObject;
    private bool isColliding = false;
    public string objectTag;

    public HorseEffects hfx;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {        
        RideHorse();
        FeedHorse();
        Move();
    }
    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * moveSpeed * Time.fixedDeltaTime);
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
    private void RideHorse()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (collidedObject != null && horseGettingRidden == null)
            {
                //////////////////////////////////////////
                if (collidedObject.CompareTag("Beyazid") && !inv.hasApple && isColliding)
                {

                    StartRiding();
                }
                else
                {
                }
                //////////////////////////////////////////
                if (collidedObject.CompareTag("Donkey") && !inv.hasCarrot && isColliding)
                {

                    StartRiding();
                }
                else
                {
                }
                //////////////////////////////////////////
                if (collidedObject.CompareTag("Gulpembe") && !inv.hasBrush && isColliding)
                {

                    StartRiding();
                }
                else
                {
                }
                //////////////////////////////////////////
                if (collidedObject.CompareTag("Juan") && !inv.hasWhip && isColliding)
                {

                    StartRiding();
                }
                else
                {
                }
                //////////////////////////////////////////
                if (collidedObject.CompareTag("twig") && isColliding)
                {

                    StartRiding();
                }
                else
                {
                }
                //////////////////////////////////////////
            }
            else if(horseGettingRidden)
            {
                StopRidingHorse();
            }
        }

        if (animator.GetFloat("Speed") > 0)
        {
            isMoving = true;
        }
        else if (animator.GetFloat("Speed") == 0)
        {
            isMoving = false;
        }
    }
    private void FeedHorse()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (collidedObject != null)
            {
                ///////////////////////////
                if (collidedObject.CompareTag("Beyazid") && inv.selectedItem == 1 && isColliding)
                {
                    hfx.Elma();
                    inv.hasApple = false;
                    appleIcon.color = Color.black;
                    inv.selectedItem = 0;
                    inv.selectedItem = 0;
                    inv.NewItemSelected();
                }
                else
                {
                    if (inv.hasApple)
                    {

                    }
                }
                ////////////////////////////////////
                if (collidedObject.CompareTag("Donkey") && inv.selectedItem == 2 && isColliding)
                {
                    StartCoroutine("EssekYemek");
                    inv.hasCarrot = false;
                    carrotIcon.color = Color.black;
                    inv.selectedItem = 0;
                    inv.selectedItem = 0;
                    inv.NewItemSelected();
                }
                else
                {
                    if (inv.hasCarrot)
                    {
                        hfx.EssekSinirli();

                    }
                }
                //////////////////////////////////////
                if (collidedObject.CompareTag("Gulpembe") && inv.selectedItem == 3 && isColliding)
                {
                    hfx.Timar();
                    inv.hasBrush = false;
                    brushIcon.color = Color.black;
                    inv.selectedItem = 0;
                    inv.selectedItem = 0;
                    inv.NewItemSelected();
                }
                else
                {
                    if (inv.hasBrush)
                    {

                    }
                }
                //////////////////////////////////
                if (collidedObject.CompareTag("Juan") && inv.selectedItem == 4 && isColliding)
                {
                    hfx.Kirbac();
                    inv.hasWhip = false;
                    whipIcon.color = Color.black;
                    inv.selectedItem = 0;
                    inv.NewItemSelected();
                }
                else
                {
                    if (inv.hasWhip)
                    {

                    }
                }
                ////////////////////////////////
            }
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

        if (objectTag != null)
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
        animator.SetBool(objectTag, false);
        objectTag = null;
        Instantiate(horseGettingRidden, transform.position, transform.rotation);
        horseGettingRidden = null;
    }
    private void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", Mathf.Clamp(movement.sqrMagnitude,0,1));

        if (inv.selectedItem > 0)
        {
            animator.SetBool("Holding", true);
        }
        else
        {
            animator.SetBool("Holding", false);
        }
    }
    public void PlayAudio()
    {

    }

    IEnumerator EssekYemek()
    {
        hfx.Havuc();
        yield return new WaitForSeconds(1);
        hfx.EssekMutlu();
    }
}