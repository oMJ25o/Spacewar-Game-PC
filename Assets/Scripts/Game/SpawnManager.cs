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
            FindCamera();
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
        RandomLocation();

        Instantiate(enemyPrefabs[0], new Vector2(cam.position.x + xOffSet, cam.position.y + yOffSet), enemyPrefabs[0].transform.rotation);

        StartCoroutine("SpawnTimer");
    }

    private void RandomLocation()
    {
        xOffSet = Random.Range(-100, 101);

        if (xOffSet <= 81)
        {
            int verticalSpawn = Random.Range(1, 3);
            switch (verticalSpawn)
            {
                case 1:
                    yOffSet = Random.Range(60, 71);
                    return;
                case 2:
                    yOffSet = Random.Range(-60, -71);
                    return;
            }
        }
        else
        {
            yOffSet = Random.Range(60, -71);
        }
    }

    private void FindCamera()
    {
        cam = GameObject.Find("Main Camera").transform;
    }
}
