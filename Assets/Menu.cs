using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsMenu;
    public GameObject optionsMenu;
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OptionsButton()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }
    public void CreditsButton()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void BackButton()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        Debug.Log("as,,");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
