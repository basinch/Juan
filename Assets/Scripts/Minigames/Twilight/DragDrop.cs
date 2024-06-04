using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public GameObject objectToDrag;
    public GameObject objectDragToPosition;

    public float dropDistance;

    public bool isLocked;

    Vector2 objectInitPosition;

    // Start is called before the first frame update
    void Start()
    {
        objectInitPosition = objectToDrag.transform.position;
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
        }
        else
        {
            objectToDrag.transform.position = objectInitPosition;
        }
    }
}
