using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    float spawnTime = 5.0F;

    [SerializeField]
    Transform[] positions;

    [SerializeField]
    GameObject[] enemyPrefabs;

    float currentTime = 0.0F;


    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= spawnTime)
        {
            currentTime = 0.0F;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Transform position = positions[Random.Range(0, positions.Length)];

        Instantiate(prefab, position.position, Quaternion.identity);
    }

}
