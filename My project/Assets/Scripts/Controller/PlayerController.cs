using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [Header("Input")]
    public FixedJoystick Joystick;
    private float verticalInput;
    private float horizontalInput;
    [Header("Movevement")]
    private float moveSpeed = 200f;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private Slider powerBar;
    private float maxJumpForce = 100f;
    public float currentJumpForce = 0f;
    private Vector2 jump;
    [Header("Status")]
    public bool isAlive;
    //private bool isFreezed;
    private bool grounded;
    public int personalScore;
    //private int damage;
    private bool facingRight = true;
    private float currentTime;
    private float startingTime = 3;
    private bool readyToJump;
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Awake()
    {
        MakeInstance();
    }

    private void Start()
    {
        currentTime = startingTime;
        isAlive = true;
        readyToJump = false;
        //isFreezed = false;
        personalScore = 0;
        //damage = 1;

        powerBar.value = currentJumpForce;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        MovevementInput();
        Movement();
        Animation();
        //condition to flip
        if (facingRight == false && horizontalInput > 0 && verticalInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && horizontalInput < 0 && verticalInput > 0)
        {
            Flip();
        }
        //condition prepare to jump
        if (verticalInput < 0 && grounded == true && horizontalInput != 0)
        {
            PrepareToJump();
        }
        //condition to jum
        if (verticalInput == 0 && horizontalInput == 0 && readyToJump == true)
        {
            Jump();
        }
        //Cancel jump
        if (readyToJump == true && verticalInput > 0 && currentJumpForce > 0)
        {
            anim.SetBool("Ready", false);
            currentJumpForce = 0;
            readyToJump = false;
            jump = new Vector2(0, 0);
            powerBar.value = currentJumpForce;
        }
    }

    void MovevementInput()
    {
        verticalInput = Joystick.Vertical;
        horizontalInput = Joystick.Horizontal;
    }

    void Movement()
    {
        if (verticalInput > 0)
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed * Time.deltaTime, rb.velocity.y);
        }
    }

    void Animation()
    {
        //anim walk
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.magnitude * moveSpeed));
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void PrepareToJump()
    {
        anim.SetBool("Ready", true);
        //increase force by time
        if (currentJumpForce < maxJumpForce)
        {
            currentTime -= 1 * Time.deltaTime;
            currentJumpForce += maxJumpForce / startingTime * Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0;
                currentJumpForce = maxJumpForce;
            }
            powerBar.value = currentJumpForce;
        }
        //create jump vector
        if (verticalInput < 0)
        {
            jump = new Vector2(horizontalInput * -1, verticalInput * -1);
            readyToJump = true;
        }
    }

    void Jump()
    {
        anim.SetBool("Ready", false);
        anim.SetBool("Jump", true);
        if (readyToJump == true)
        {
            rb.AddForce(jump * currentJumpForce, ForceMode2D.Impulse);
        }
        readyToJump = false;
        currentJumpForce = 0;
        currentTime = startingTime;
        powerBar.value = currentJumpForce;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            anim.SetBool("Jump", false);
            grounded = true;
        }
        if (other.gameObject.tag == "Point")
        {
            personalScore++;
        }
        if (other.gameObject.tag == "Die")
        {
            anim.SetBool("die", true);
            isAlive = false;
            if(GameManager.gameManager != null)
            {
                if(personalScore > GameManager.gameManager._GetHighScore())
                {
                    GameManager.gameManager._SetHighScore(personalScore);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            grounded = false;
        }
    }
}
