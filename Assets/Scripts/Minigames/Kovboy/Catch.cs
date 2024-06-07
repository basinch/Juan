using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Catch : MonoBehaviour
{
    public GameObject caughtHorse;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Juan"))
        {
            Destroy(other.gameObject);
        }
            caughtHorse.SetActive(true);
        StartCoroutine(LoadNextSceneAfterDelay(3f));
    }
    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings ? 0 : SceneManager.GetActiveScene().buildIndex + 1);
    }
}
