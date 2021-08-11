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
        if (Input.GetKey(KeyCode.UpArrow) && rb.velocity.y==0)
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
            animator.SetBool("isIdle", false);
            animator.SetBool("isJumping", false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            animator.SetBool("isRunning", true);
            animator.SetBool("isIdle", false);
            animator.SetBool("isJumping", false);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", true);
            animator.SetBool("isIdle", false);
        }
        if (!(Input.GetKey(KeyCode.UpArrow)) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.Space)) 
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", false);
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

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        animator.SetBool("isGrounded", false);
    }
}
