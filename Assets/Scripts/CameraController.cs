using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private float smoothSpeed = 0.08f; 
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    public float cameraFrontViewMultiplier = 3;
    [SerializeField] private float cameraFrontViewSpeed = 0.07f;

    void FixedUpdate()
    {
        ///if (target != null)
        ///{
           /// Vector3 desiredPosition = target.position + offset;
           /// Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
           /// transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        ///}
        /////////////////////////////
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 movementInput = new Vector2(horizontalInput, verticalInput).normalized;
        //////////////////////////////////
        Vector3 destinedOffset = new Vector3(horizontalInput * cameraFrontViewMultiplier, verticalInput * cameraFrontViewMultiplier, -10f);
        Vector3 smoothedOffset = Vector3.Lerp(offset, destinedOffset, cameraFrontViewSpeed);
        offset = new Vector3(smoothedOffset.x, smoothedOffset.y, -10f);

    }
}