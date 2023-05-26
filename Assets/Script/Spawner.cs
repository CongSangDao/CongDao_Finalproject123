using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject powerupPrefab;
    public GameObject obstaclePrefab;
    public float spawnCycle = .1f;

    GameManager manager;
    float elapsedTime;
    bool spawnPowerup = true;

    void Start()
    {
        manager = GetComponent<GameManager>();
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            GameObject spawnedObject;
            if (spawnPowerup)
                spawnedObject = Instantiate(powerupPrefab, transform.TransformPoint(Vector3.zero), transform.rotation);
            else
                spawnedObject = Instantiate(obstaclePrefab, transform.TransformPoint(Vector3.zero), transform.rotation);

            Collidable col = spawnedObject.GetComponent<Collidable>();
            col.manager = manager;

            if (!spawnPowerup)
            {
                float scale = Random.Range(3f, 3f);
                spawnedObject.transform.localScale = new Vector3(scale, scale, scale);
            }

            elapsedTime = 0;
            spawnPowerup = !spawnPowerup;

            yield return new WaitForSeconds(spawnCycle);
        }
    }
}
