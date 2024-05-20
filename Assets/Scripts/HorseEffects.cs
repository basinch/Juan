using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseEffects : MonoBehaviour
{
    public AudioSource audi;
    public AudioClip elma;
    public AudioClip essekMutlu;
    public AudioClip essekSinirli;
    public AudioClip havuc;
    public AudioClip kirbac;
    public AudioClip timar;
    // Start is called before the first frame update
    void Start()
    {
        audi = GetComponent<AudioSource>();
    }

    public void Elma()
    {
        AudioSource.PlayClipAtPoint(elma, transform.position);
    }
    public void EssekMutlu()
    {
        AudioSource.PlayClipAtPoint(essekMutlu, transform.position);
    }
    public void EssekSinirli()
    {
        AudioSource.PlayClipAtPoint(essekSinirli, transform.position);
    }
    public void Havuc()
    {
        AudioSource.PlayClipAtPoint(havuc, transform.position);
    }
    public void Kirbac()
    {
        AudioSource.PlayClipAtPoint(kirbac, transform.position);
    }
    public void Timar()
    {
        AudioSource.PlayClipAtPoint(timar, transform.position);
    }

    void Update()
    {
        
    }
}
