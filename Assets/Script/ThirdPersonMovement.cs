using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public float speed = 6f;             // Character movement speed
    public float turnSmoothTime = 0.1f;  // Smooth time for character rotation
    public Transform cameraTransform;    // Reference to the main camera transform

    private CharacterController controller;   // Character controller component
    private float turnSmoothVelocity;         // Velocity for smooth rotation

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Get the player's input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Only move if there is input
        if (direction.magnitude >= 0.1f)
        {
            // Calculate the target angle based on the camera's forward direction
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;

            // Smoothly rotate the character towards the target angle
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Calculate the movement direction based on the target angle
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Move the character based on the movement direction and speed
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
    }
}
