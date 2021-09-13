using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Enemy1
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        secondsKeeper = waitingSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MovementTwoSidesWithoutFlip();
    }

    protected void MovementTwoSidesWithoutFlip()
    {
        if (!changeSides)
        {
            waitingSeconds -= Time.deltaTime;
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
        }
        else
        {
            waitingSeconds -= Time.deltaTime;
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
        }
        if (waitingSeconds <= 0f)
        {
            waitingSeconds = secondsKeeper;
            ChangeSides();
        }
    }
}
