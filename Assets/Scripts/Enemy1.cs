using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [Header("Movement setup bool")]
    [Tooltip("If false it moves one side, if true it moves from side to side depending on seconds variable below")]
    [SerializeField] protected bool changeMovement;
    [SerializeField] protected float waitingSeconds;
    [SerializeField] protected float movementSpeed;
    protected bool changeSides;
    protected float secondsKeeper;
    protected Rigidbody2D rb;
    protected SpriteRenderer sr;
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
        if (!changeMovement)
        {
            MovementOneSide();
        }
        else
        {
            MovementTwoSides();
        }
    }
    void MovementOneSide() 
    {
        rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
    }

    protected void MovementTwoSides() 
    {
        if (!changeSides)
        {
             waitingSeconds -= Time.deltaTime;
             sr.flipX = true;
             rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
        }
        else 
        {
             waitingSeconds -= Time.deltaTime;
             sr.flipX = false;
             rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
        }
        if (waitingSeconds<=0f) 
        {
            waitingSeconds = secondsKeeper;
            ChangeSides();
        }
    }

    protected void ChangeSides() 
    {
        if (changeSides)
        {
            changeSides = false;
        }
        else 
        {
            changeSides = true;
        }
    }
}
