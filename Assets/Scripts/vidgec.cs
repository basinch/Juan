using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vidgec : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(viddgec());
    }
    IEnumerator viddgec()
    {
        yield return new WaitForSeconds(15);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
