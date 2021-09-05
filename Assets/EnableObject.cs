using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : MonoBehaviour
{
    [SerializeField] List<GameObject> objectsToEnable = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < objectsToEnable.Count; i++) 
        {
            objectsToEnable[i].SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            for (int i = 0; i < objectsToEnable.Count; i++)
            {
                objectsToEnable[i].SetActive(true);
            }
        }
    }
}
