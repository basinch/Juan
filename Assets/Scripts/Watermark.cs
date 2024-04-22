using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Watermark : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeScene());
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * 1.2f, Time.deltaTime);
    }
    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
