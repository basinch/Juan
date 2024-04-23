using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemScriptableObj itemScriptableObject;

    Vector2 originalPos;

    private void Start()
    {
        originalPos = gameObject.transform.localPosition;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D))
        {
            gameObject.transform.localPosition = new Vector2(0.085f, 0.06f);
            transform.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }
        else
        {
            gameObject.transform.localPosition = originalPos;
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }
}
