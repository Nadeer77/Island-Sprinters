using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int coins;
    public int health = 100;
    public float moveSpeed = 10f;
    public float jumpHeight = 10f;
    private bool isDead = false;
    public float groundCheckRadius = 0.2f;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;
    public int extraJumpsValue = 1;
    private int extraJumps;
    public Image healthImage;

    private AudioSource audioSource;
    public AudioClip jumpClip;
    public AudioClip hurtClip;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
                
        extraJumps = extraJumpsValue; 
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if(isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
                PlaySFX(jumpClip, 0.4f);
            }
            else if(extraJumps>0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
                extraJumps--;
            }
        }

        SetAnimation(moveInput);

        Flip();

        healthImage.fillAmount = health / 100f;
    }
    void FixedUpdate()
    {
        // to check if  player is grounded or not
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    private void SetAnimation(float moveInput)
    {
        if (isGrounded)
        {
            if (moveInput == 0)
            {
                animator.Play("Idle");
            }
            else
            {
                animator.Play("Run");
            }
        }
        else
        {
            if (rb.linearVelocityY > 0)
            {
                animator.Play("Jump");
            }
            else
            {
                animator.Play("Fall");
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // If player hits the enemy's body (child collider tagged "Damage")
        if (collision.gameObject.CompareTag("Damage"))
        {
            if (isDead) return; // Ignore further damage

            PlaySFX(hurtClip, 0.4f);
            health -= 25;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
            StartCoroutine(BlinkRed());

            if (health <= 0)
            {
                isDead = true; // Mark dead
                Die();
            }
    }

        else if (collision.gameObject.CompareTag("BouncePad"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight * 1.5f);
        }
    }
    public IEnumerator BlinkRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
    private void Die()
    {
        GameManager.instance.PlayerDied();
        Time.timeScale = 0;
        RestartGame.instance.GameOverPanel.SetActive(true);
    }

    void Flip()
    {
        if (rb.linearVelocity.x < 0f)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    public void PlaySFX(AudioClip clip, float volume)
    {
        audioSource.volume = volume;
        audioSource.clip = clip;
        audioSource.Play();
    }
}
