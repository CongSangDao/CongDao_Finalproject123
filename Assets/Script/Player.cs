using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    public GameManager manager;
    public Material normalMat;

    [Header("Gameplay")]
    public float bounds = 3f;
    public float strafeSpeed = 4f;

    Renderer mesh;
    Collider collision;

    private bool isGameOver = false;

    void Start()
    {
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        collision = GetComponent<Collider>();
    }

    void Update()
    {
        if (isGameOver) // Check if the game is already over
            return;

        float xMove = Input.GetAxis("Horizontal") * Time.deltaTime * strafeSpeed;

        Vector3 position = transform.position;
        position.x += xMove;
        position.x = Mathf.Clamp(position.x, -bounds, bounds);
        transform.position = position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            isGameOver = true;
            manager.GameOver();
        }
    }
}
