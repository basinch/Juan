using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMinigameHorse : MonoBehaviour
{
    [SerializeField] float distanceToCover;
    [SerializeField] float speed;

    private Vector2 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = startingPosition;
        v.x += distanceToCover * 2 * Mathf.Sin(Time.time * speed / 2);
        transform.position = v;
    }
}