using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("asd");
        if (other.CompareTag("Beyazid") ||
            other.CompareTag("Donkey") ||
            other.CompareTag("Gulpembe") ||
            other.CompareTag("Juan") ||
            other.CompareTag("twig"))
        {
            Destroy(other.gameObject);
        }

    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
