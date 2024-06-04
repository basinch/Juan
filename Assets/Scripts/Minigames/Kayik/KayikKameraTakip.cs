using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KayikKameraTakip : MonoBehaviour
{
    public Transform target;
    public float height;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, target.position.y + height, -10);
    }
}
