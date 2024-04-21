using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarnSceneChanger : MonoBehaviour
{
    public PlayerInventory inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inventory.hasApple == true && inventory.hasCarrot == true && inventory.hasBrush == true && inventory.hasWhip == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

