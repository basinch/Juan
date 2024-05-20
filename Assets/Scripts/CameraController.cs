using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float smoothSpeed = 1f; 
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    public float cameraFrontViewMultiplier = 3;
    [SerializeField] private float cameraFrontViewSpeed = 0.005f;
    private float camSpeedPH;
    [SerializeField] private float comeBackSpeed = 1.7f;
    private GameObject player;
    private PlayerMovement playerMove;
    private void Start()
    {
        camSpeedPH = cameraFrontViewSpeed;
    }
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerMove = player.GetComponent<PlayerMovement>();
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
        /////////////////////////////
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 movementInput = new Vector2(horizontalInput, verticalInput).normalized;
        if (movementInput != Vector2.zero)
        {

            if (movementInput.x > 0)
            {
                Vector3 destinedOffset = new Vector3(cameraFrontViewMultiplier, 0, -10f);
                Vector3 smoothedOffset = Vector3.Lerp(offset, destinedOffset, cameraFrontViewSpeed);
                offset = new Vector3(smoothedOffset.x, smoothedOffset.y, -10f);
            }
            if (movementInput.x < 0)
            {
                Vector3 destinedOffset = new Vector3(-cameraFrontViewMultiplier, 0, -10f);
                Vector3 smoothedOffset = Vector3.Lerp(offset, destinedOffset, cameraFrontViewSpeed);
                offset = new Vector3(smoothedOffset.x, smoothedOffset.y, -10f);
            }

            if (movementInput.y > 0)
            {
                Vector3 destinedOffset = new Vector3(0, cameraFrontViewMultiplier,-10f);
                Vector3 smoothedOffset = Vector3.Lerp(offset, destinedOffset, cameraFrontViewSpeed);
                offset = new Vector3(smoothedOffset.x, smoothedOffset.y, -10f);
            }
            if (movementInput.y < 0)
            {
                Vector3 destinedOffset = new Vector3(0, -cameraFrontViewMultiplier, -10f);
                Vector3 smoothedOffset = Vector3.Lerp(offset, destinedOffset, cameraFrontViewSpeed);
                offset = new Vector3(smoothedOffset.x, smoothedOffset.y, -10f);
            }
        }
        else
        {
            Vector3 destinedOffset = new Vector3(0, 0, -10f);
            Vector3 smoothedOffset = Vector3.Lerp(offset, destinedOffset, cameraFrontViewSpeed*comeBackSpeed);
            offset = new Vector3(smoothedOffset.x, smoothedOffset.y, -10f);
        }

    }
}