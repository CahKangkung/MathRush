using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SectionTrigger : MonoBehaviour
{
    public GameObject roadSection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(roadSection, new Vector3(+17.6f, +11.2f, +753), Quaternion.identity);
        }
        
    }

}
