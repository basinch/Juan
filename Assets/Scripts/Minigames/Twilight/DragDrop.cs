using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragDrop : MonoBehaviour
{
    public GameObject objectToDrag;
    public GameObject objectDragToPosition;
    public GameObject starCounter;
    public StarCounter star;

    public float dropDistance;

    public bool isLocked;

    Vector2 objectInitPosition;

    // Start is called before the first frame update
    void Start()
    {
        objectInitPosition = objectToDrag.transform.position;
        starCounter = GameObject.FindWithTag("event");
        star = starCounter.GetComponent<StarCounter>();
    }

    public void DragObject()
    {
        if(!isLocked)
        {
            objectToDrag.transform.position = Input.mousePosition;
        }
    }

    public void DropObject()
    {
        float Distance = Vector3.Distance(objectToDrag.transform.position, objectDragToPosition.transform.position);

        if(Distance < dropDistance)
        {
            isLocked = true;
            objectToDrag.transform.position = objectDragToPosition.transform.position;
            star.starCount += 1;
        }
        else
        {
            objectToDrag.transform.position = objectInitPosition;
        }
    }
}
