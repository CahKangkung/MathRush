using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAddAI : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float laneOffset = 2.5f; // Jarak antar lane
    public float spawnZOffset = 5f; // Offset ke depan dari Road_Section

    void Start()
    {
        SpawnObstacles();
    }

    void SpawnObstacles()
    {
        // Definisikan jalur: -1 (kiri), 0 (tengah), 1 (kanan)
        List<int> lanes = new List<int> { -1, 0, 1 };

        // Tentukan berapa banyak obstacle yang akan spawn (0, 1, atau 2)
        int obstacleCount = Random.Range(0, 3); // 0, 1, atau 2 obstacle

        // Shuffle lanes untuk pilih jalur secara random
        for (int i = 0; i < lanes.Count; i++)
        {
            int randomIndex = Random.Range(i, lanes.Count);
            int temp = lanes[i];
            lanes[i] = lanes[randomIndex];
            lanes[randomIndex] = temp;
        }

        // Spawn obstacle di jalur yang dipilih
        for (int i = 0; i < obstacleCount; i++)
        {
            int laneIndex = lanes[i];

            Vector3 spawnPosition = transform.position + new Vector3(laneIndex * laneOffset, 0, spawnZOffset);
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
