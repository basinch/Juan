using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FootstepPrototype : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject lanetUnityObjesi;

    void Start()
    {
        lanetUnityObjesi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.isMoving == true)
        {
            lanetUnityObjesi.SetActive (true);
        }
        if(playerController.isMoving == false)
        {
            lanetUnityObjesi.SetActive(false);
        }
    }
}
