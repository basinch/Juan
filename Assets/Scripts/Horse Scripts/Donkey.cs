using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donkey : MonoBehaviour, IHorses
{
    // Start is called before the first frame update
    void Start()
    {
        BeHappy();
    }
    public void BeHappy()
    {
        Debug.Log("hapy");
    }
    public void BeAngry()
    {
        Debug.Log("angy");

    }
    public void StartRiding()
    {
        Debug.Log("ismet bindi");
    }
    public void StopRiding()
    {
        Debug.Log("ismet indi");
    }
    // Update is called once per frame
    void Update()
    {
    }
}
