using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FootstepPrototype : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject lanetUnityObjesi, serefsizUnityObjesi;

    void Start()
    {
        lanetUnityObjesi.SetActive(false);
        serefsizUnityObjesi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.isMoving == true && playerController.horseGettingRidden == null)
        {
            lanetUnityObjesi.SetActive (true);
        }
        else if(playerController.isMoving == true && playerController.horseGettingRidden != null)
        {
            serefsizUnityObjesi.SetActive(true);
        }
        if(playerController.isMoving == false)
        {
            lanetUnityObjesi.SetActive(false);
            serefsizUnityObjesi.SetActive(false);
        }
    }
}
