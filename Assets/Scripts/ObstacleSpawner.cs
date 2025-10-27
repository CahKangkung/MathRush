using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float laneOffset = 2.5f; // Jarak antar lane dari tengah
    public float spawnZOffset = 5f; // Offset ke depan supaya obstacle tidak pas di belakang player

    void Start()
    {
        SpawnObstacle();
    }

    void SpawnObstacle()
    {
        // Pilih acak lane: -1 (kiri), 0 (tengah), 1 (kanan)
        int laneIndex = Random.Range(-1, 2); // -1, 0, 1

        Vector3 spawnPosition = transform.position + new Vector3(laneIndex * laneOffset, 0, spawnZOffset);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
    
}
