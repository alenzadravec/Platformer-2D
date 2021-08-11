using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger");
        if (other.tag == "Player")
        {
            Debug.Log("Picked up a coin!");
            Destroy(gameObject);
        }
    }
}
