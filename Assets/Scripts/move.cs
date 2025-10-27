using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    //Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, -20) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }

    public GameObject obstaclePrefab;
    
    void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);

    }

}
