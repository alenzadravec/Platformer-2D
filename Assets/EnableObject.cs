using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : MonoBehaviour
{
    [SerializeField] GameObject objectToEnable;

    private void Start()
    {
        objectToEnable.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            objectToEnable.SetActive(true);
        }
    }
}
