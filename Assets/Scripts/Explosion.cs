using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.PlayOneShot(audio.GetComponent<AudioSource>().clip);

        Destroy(gameObject, audio.GetComponent<AudioSource>().clip.length);
    }
}