using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{
    public GameObject caughtHorse;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("target"))
        {
            Destroy(other.gameObject);
        }
            caughtHorse.SetActive(true);
    }
}
