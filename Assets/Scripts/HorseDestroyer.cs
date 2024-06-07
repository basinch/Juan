using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HorseDestroyer : MonoBehaviour
{
    public int endGameCounter = 0;
    public HorseScript horseScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("asd");
        if (horseScript != null || horseScript.isFriend)
        {
            if (other.CompareTag("Beyazid") ||
                 other.CompareTag("Donkey") ||
                 other.CompareTag("Gulpembe") ||
                 other.CompareTag("Juan") ||
                 other.CompareTag("twig") ||
                other.CompareTag("Sacit "))
            {
                Destroy(other.gameObject);
                horseScript = other.gameObject.GetComponent<HorseScript>();
                endGameCounter++;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        horseScript = null;
    }
    // Update is called once per frame
    void Update()
    {
        if(endGameCounter == 5)
        {
            SceneManager.LoadScene(7);
        }
    }
}
