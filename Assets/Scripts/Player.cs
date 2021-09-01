using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float shootSpeed;
    [SerializeField] float bulletLife;
    [SerializeField] float timeBetweenShots;

    [SerializeField] Transform positionLeft;
    [SerializeField] Transform positionRight;
    [SerializeField] GameObject bullet;
    [SerializeField] SpriteRenderer background;

    private bool isShotting;
    private bool upArrowEnabled;

    AudioSource audio;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        isShotting = false;
        upArrowEnabled = true;
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.SetBool("isRunning", false);
    }

    private void Update()
    {
        if (gameObject.GetComponent<DamageTaker>().GetCurrentHealthAmount() <= 50 && gameObject.GetComponent<DamageTaker>().GetCurrentHealthAmount()>=25)
        {
            background.color = new Color32(255, 148, 148, 255);//light red
        }
        else if (gameObject.GetComponent<DamageTaker>().GetCurrentHealthAmount() < 25)
        {
            background.color = new Color32(255, 71, 71, 255); //red
        }
        else 
        {
            background.color = new Color32(255, 255, 255, 255);//default white
        }

        #region Movement
        if (Input.GetKeyDown(KeyCode.UpArrow) && rb.velocity.y==0 && upArrowEnabled)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        movement = new Vector2(Input.GetAxis("Horizontal"),0f);

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("MainCharRun")) //prevention from shooting while running
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isShotting)
            {
                StartCoroutine("Shoot");
            }
        }
        #endregion

        #region Animation
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            animator.ResetTrigger("Shoot"); //putting it to false so animation cannot be triggered before other action and be player after finishing it
            animator.SetBool("isRunning", true);
            animator.SetBool("isIdle", false);
            animator.SetBool("isJumping", false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            animator.ResetTrigger("Shoot");
            animator.SetBool("isRunning", true);
            animator.SetBool("isIdle", false);
            animator.SetBool("isJumping", false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && animator.GetBool("isGrounded"))
        {
            animator.ResetTrigger("Shoot");
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", true);
            animator.SetBool("isIdle", false);
        } 
        else if (Input.GetKey(KeyCode.UpArrow) && !animator.GetBool("isGrounded")) 
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isIdle", true);
        }
        if (!(Input.GetKey(KeyCode.UpArrow)) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.Space)) 
        {
            animator.ResetTrigger("Shoot");
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
        FindObjectOfType<LevelLoader>().SetLoseTrue();
    }

    public IEnumerator Shoot() 
    {
        Debug.Log("Shoot");
        audio.PlayOneShot(audio.GetComponent<AudioSource>().clip);
        isShotting = true;

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("MainCharJump")) // to prevent triggering shooting animation after jump
        {
            animator.SetTrigger("Shoot");
        }

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
        yield return new WaitForSeconds(timeBetweenShots);
        isShotting = false;
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            Debug.Log("Wall");
            upArrowEnabled = false;
        }
        else 
        {
            upArrowEnabled = true;
        }
    }
}
