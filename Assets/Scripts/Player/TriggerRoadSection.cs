using System.Collections;
using System.Collections.Generic;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

public class TriggerRoadSection : MonoBehaviour
{
    public GameObject roadSection;
    // public float sectionLength = 53.84f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            // Instantiate(roadSection, new Vector3(+17.6f, +11.2f, -51.2f), Quaternion.identity);
            // Instantiate(roadSection, new Vector3(0, 0, 62), Quaternion.identity);
            // Vector3 spawnPos = other.transform.parent.position + new Vector3(0, 0, 53.8f);
            Vector3 spawnPos = other.transform.parent.position + new Vector3(0, 0, 107.6f);
            Instantiate(roadSection, spawnPos, Quaternion.identity);
        }

    }
}
