using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinScript : MonoBehaviour
{
    public void GoBacktoMenu()
    {
        SceneManager.LoadScene(1);
    }
}
