using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public float moveSpeed = 3f; // Speed at which the animal moves towards the player

    public float followDistance = 100f; // Maximum distance for the animal to start following the player
    public float stopDistance = 2f; // Distance at which the animal stops following the player

    private bool isFollowing = false; // Flag to indicate if the animal is currently following the player

    void Update()
    {
        if (playerTransform != null)
        {
            // Calculate the distance between the animal and the player
            float distance = Vector3.Distance(transform.position, playerTransform.position);

            if (isFollowing)
            {
                // If the animal is already following, check if it should stop following
                if (distance <= stopDistance)
                {
                    isFollowing = false;
                }
            }
            else
            {
                // If the animal is not following, check if it should start following
                if (distance <= followDistance)
                {
                    isFollowing = true;
                }
            }

            // If the animal should follow the player, move towards the player
            if (isFollowing)
            {
                // Calculate the direction from the animal to the player
                Vector3 direction = playerTransform.position - transform.position;
                direction.y = 0f; // Keep the animal at the same height

                // Normalize the direction to get a unit vector
                direction.Normalize();

                // Move the animal towards the player
                transform.position += direction * moveSpeed * Time.deltaTime;

                // Rotate the animal to face the player
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}
