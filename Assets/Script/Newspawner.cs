using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform spawnPoint;
    public float spawnInterval = 2f;

    private void Start()
    {
        // Start spawning obstacles
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
    }

    private void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);
    }
}
