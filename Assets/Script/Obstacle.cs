using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player collided with the obstacle
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
            else
            {
                // Handle game over logic directly here
                // Example: Restart the level or show a game over screen
            }
        }
    }
}
