using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] Transform positionLeft;
    [SerializeField] Transform bulletAngle;
    [SerializeField] GameObject bullet;
    [SerializeField] float shootSpeed;
    [SerializeField] float bulletLife;

    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Shoot() 
    {
//        Debug.Log("Shoot");
        audio.PlayOneShot(audio.GetComponent<AudioSource>().clip);

        GameObject newBullet = Instantiate(bullet, positionLeft.position, bulletAngle.localRotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * -shootSpeed;
        Destroy(newBullet, bulletLife);
    }
}
