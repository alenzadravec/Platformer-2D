using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            audio.PlayOneShot(audio.GetComponent<AudioSource>().clip);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            Debug.Log("Picked up a coin!");
            FindObjectOfType<CoinCounter>().IncreaseCoins(1);
            Destroy(gameObject, audio.GetComponent<AudioSource>().clip.length); 
        }
    }
}
