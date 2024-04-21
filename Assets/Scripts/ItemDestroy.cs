using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{

    public PlayerInventory inventory;

    public bool canDestroy = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            canDestroy = true;
        }

        if(Input.GetKeyUp(KeyCode.E))
        {
            canDestroy = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(canDestroy == true && collision.tag == "Apple")
        {
            inventory.hasApple = true;
            Destroy(collision.gameObject);

        }
        if (canDestroy == true && collision.tag == "Carrot")
        {
            inventory.hasCarrot = true;
            Destroy(collision.gameObject);
        }
        if (canDestroy == true && collision.tag == "Brush")
        {
            inventory.hasBrush = true;
            Destroy(collision.gameObject);
        }
        if (canDestroy == true && collision.tag == "Whip")
        {
            inventory.hasWhip = true;
            Destroy(collision.gameObject);
        }
    }
}