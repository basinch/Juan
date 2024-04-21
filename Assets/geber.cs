using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geber : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("asd");
        if (other.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
