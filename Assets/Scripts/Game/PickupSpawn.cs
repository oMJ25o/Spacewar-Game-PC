using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] weaponPickups;
    [SerializeField] private Vector3[] spawnLocations;
    [SerializeField] private bool[] isEmpty;
    [SerializeField] private float spawnTimer;

    private int weapNum;
    private int locNum;
    // Start is called before the first frame update
    void Start()
    {
        EventController.current.onPlayerWeaponPickup += VacateSpawnLocation;
        SpawnPickup();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnPickup()
    {
        GenerateRandomSpawn();
        Instantiate(weaponPickups[weapNum], spawnLocations[locNum], weaponPickups[weapNum].transform.rotation);
        isEmpty[locNum] = false;
        StartCoroutine(SpawnTimer());
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(spawnTimer);
        SpawnPickup();
    }

    private void GenerateRandomSpawn()
    {
        weapNum = Random.Range(0, weaponPickups.Length);
        while (true)
        {
            locNum = Random.Range(0, spawnLocations.Length);
            if (isEmpty[locNum] == true) { break; }
        }
    }

    private void VacateSpawnLocation(GameObject weaponPickup)
    {
        for (int i = 0; i < spawnLocations.Length; i++)
        {
            if (weaponPickup.transform.position == spawnLocations[i])
            {
                isEmpty[i] = true;
                break;
            }
        }
    }
}
