using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int spawnTimer;

    private int xOffSet;
    private int yOffSet;

    private Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = GameObject.Find("Main Camera").transform;
        }
        SpawnEnemy();
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(spawnTimer);
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        // Generate the Vector3 Values for the spawn location
        RandomLocation();

        // Spawn the enemy
        Instantiate(enemyPrefabs[0], new Vector2(cam.position.x + xOffSet, cam.position.y + yOffSet), enemyPrefabs[0].transform.rotation);

        // Start the Spawn Delay Timer
        StartCoroutine("SpawnTimer");

        // Can be added more
        // Generate a random int to spawn multiple enemies
        // Generate a natural spawn formation based on how long the player's survival time
    }

    private void RandomLocation()
    {
        // Generate X location
        xOffSet = Random.Range(-25, 25);

        // Prevent the enemy to spawn inside the camera
        if (xOffSet <= 81)
        {
            // Generate a 1 and 2 value to determine if the spawn will be either in the north or south side of the camera
            int verticalSpawn = Random.Range(1, 3);
            switch (verticalSpawn)
            {
                case 1:
                    yOffSet = Random.Range(13, 20);
                    return;
                case 2:
                    yOffSet = Random.Range(-13, -20);
                    return;
            }
        }
        else // If the generated X value will not be inside the camera
        {
            yOffSet = Random.Range(20, -20);
        }
    }
}
