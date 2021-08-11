using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float shootSpeed;
    [SerializeField] float bulletLife;

    [SerializeField] Transform positionLeft;
    [SerializeField] Transform positionRight;
    [SerializeField] GameObject bullet;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.SetBool("isRunning", false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && rb.velocity.y==0)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        movement = new Vector2(Input.GetAxis("Horizontal"),0f);

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Shoot();
        }

        #region Animation
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            animator.SetBool("isRunning", true);
        }
        else 
        {
            if (rb.velocity.x==0f)
            {
                animator.SetBool("isRunning", false);
            }
        }
        #endregion

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * movementSpeed,rb.velocity.y);
    }

    public void KillPlayer() 
    {
        Debug.Log("Kill player");
    }

    public void Shoot() 
    {
        Debug.Log("Shoot");

        if (sr.flipX)
        {
           GameObject newBullet = Instantiate(bullet, positionLeft.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * -shootSpeed;
            Destroy(newBullet, bulletLife);
        }
        else 
        {
            GameObject newBullet = Instantiate(bullet, positionRight.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * shootSpeed;
            Destroy(newBullet, bulletLife);
        }
    }
}
