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

    int enemiesSpawned = 0; // contador de enemigos creados
    int maxEnemies = 5; // cantidad máxima de enemigos permitidos

    float currentTime = 0.0F;

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= spawnTime && enemiesSpawned < maxEnemies) // agregamos la verificación para el límite de enemigos
        {
            currentTime = 0.0F;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        if (enemiesSpawned < maxEnemies) // agregamos la verificación para el límite de enemigos
        {
            GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Transform position = positions[Random.Range(0, positions.Length)];

            Instantiate(prefab, position.position, Quaternion.identity);

            enemiesSpawned++; // incrementamos el contador de enemigos creados
        }
    }
}
