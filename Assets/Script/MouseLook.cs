using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;   // Mouse sensitivity
    public Transform playerBody;            // Reference to the player's body transform

    private float xRotation = 0f;           // Current rotation around the x-axis

    private void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Get mouse movement input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the player's body horizontally
        playerBody.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Clamp the rotation to prevent looking beyond 90 degrees up or down
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
