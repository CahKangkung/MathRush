using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSettings : MonoBehaviour
{
    public bool isFirstSection = false;
    public static bool isSpawnObstacle = true;
    
    void Start()
    {   
        //isSpawnObstacle = true;
        if (!isFirstSection && isSpawnObstacle)
        {
            SpawnObstacle();
        }
    }

    public GameObject[] obstaclePrefab;

    public void SpawnObstacle()
    {
        // int obstacleSpawnIndex = Random.Range(2, 5);
        // Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);

        Transform[] lanes = new Transform[3];
        lanes[0] = transform.Find("ObstacleSpawn_Left");
        lanes[1] = transform.Find("ObstacleSpawn_Middle");
        lanes[2] = transform.Find("ObstacleSpawn_Right");

        // Pilih jumlah spawn secara acak: 1 atau 2
        int spawnCount = Random.Range(1, 3); // 1 atau 2

        // Buat daftar index jalur: [0, 1, 2]
        List<int> laneIndices = new List<int> { 0, 1, 2 };

        // Acak urutan indeks jalur
        for (int i = 0; i < laneIndices.Count; i++)
        {
            int randIndex = Random.Range(i, laneIndices.Count);
            int temp = laneIndices[i];
            laneIndices[i] = laneIndices[randIndex];
            laneIndices[randIndex] = temp;
        }

        // Hanya spawn di 'spawnCount' pertama
        for (int i = 0; i < spawnCount; i++)
        {
            int laneIndex = laneIndices[i];
            Transform spawnPoint = lanes[laneIndex];
            SpawnRandomObstacle(spawnPoint);
        }

    }
    void SpawnRandomObstacle(Transform spawnPoint)
    {
        int prefabIndex = Random.Range(0, obstaclePrefab.Length);
        GameObject prefabToSpawn = obstaclePrefab[prefabIndex];

        Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }
}
