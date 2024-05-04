using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemyPrefab;
    public GameObject[] powerupPrefab;
    FollowPlayer followPlayer;
    PowerUp powerUp;
    public float randomRangeZ;
    public float randomRangeX;
    bool canDestroyPowerUp;
    public int spawnModifier=2;
    int counter = 1;
    int powerupCounter = 1;
    bool canSpawn = true;


    void Start()
    {
        Spawn(enemyPrefab[Random.Range(0, enemyPrefab.Length)], counter, true);
        Spawn(powerupPrefab[Random.Range(0, powerupPrefab.Length)], 1,true);


    }

    private void Update()
    {
        followPlayer = FindObjectOfType<FollowPlayer>();
        powerUp = FindObjectOfType<PowerUp>();
        if (followPlayer == null)
        {
            counter++;
            powerupCounter++;
            canSpawn = true;

            Spawn(enemyPrefab[Random.Range(0,enemyPrefab.Length)], counter, canSpawn);

            canDestroyPowerUp = true;
        }
        else
        {
            canSpawn = false;
        }
        if (powerUp != null && canDestroyPowerUp)
        {
            do
            {
                Destroy(powerUp.gameObject);

            } while (powerUp == null);
            canDestroyPowerUp = false;
        }
        Spawn(powerupPrefab[Random.Range(0, powerupPrefab.Length )], powerupCounter,canSpawn);

      
        

    }

    Vector3 randomPointOnTile()
    {
        Vector3 position = new Vector3(Random.Range(-randomRangeX, randomRangeX), 0, Random.Range(-randomRangeZ, randomRangeZ));
        return position;

    }

    void Spawn(GameObject prefab, int spawnTimer, bool canSpawn)
    {
        if (canSpawn)
        {
            for (int i = 0; i < spawnTimer; i++)
            {
                Instantiate(prefab, randomPointOnTile(), Quaternion.identity);

            }

        }



    }

   
}
