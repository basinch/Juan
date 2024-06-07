using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextSceneWithHorse : MonoBehaviour
{
    public PlayerController controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (controller.ridingHorse)
        {
            SceneManager.LoadScene(+1);
        }
    }
}
