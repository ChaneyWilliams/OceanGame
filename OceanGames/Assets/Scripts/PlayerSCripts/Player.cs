using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Pathfinding.Util.RetainedGizmos;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    SpriteFlasher flasher;
    public Color color = Color.white;
    public int numJumps = 2;
    int jumpsRemaining;
    public float baseGravity = 2f;
    public float maxFallSpeed = 10f;
    public float fallSpeedMult = 2f;

    public float timeBetweenShots = 1.5f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public GameObject WinnerUI;
    public GameObject loserUI;
    bool dead = false;
    Health health;
    public Animator animator;
    private void Start()
    {
        flasher = GetComponent<SpriteFlasher>();
        bulletPrefab.SetActive(true);
        health = GetComponent<Health>();
    }

    //see bullet script
    private void Update()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if(health.health <= 0)
        {
            Death();
        }
        Gravity();
        GroundCheck();
        Flip();
    }

    private void FixedUpdate()
    {
        if (!dead)
        {
            rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        }
        else 
        {
            
            rb.linearVelocity = Vector2.zero;
            rb.gravityScale = 0;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !flasher.isFlashing)
        {
            health.health -= 1;
            Debug.Log(health.health);
            StartCoroutine(flasher.Flash(2, color, 4));
        }
        if (collision.gameObject.CompareTag("KillBox"))
        {
            Death();
        }
        if (collision.gameObject.CompareTag("NextScene"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.gameObject.CompareTag("Winner"))
        {
            Time.timeScale = 0f;
            bulletPrefab.SetActive(false);
            WinnerUI.SetActive(true);
        }
    }
    private void GroundCheck()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer))
        {
            jumpsRemaining = numJumps;
        }
    }
    private void Flip()
    {
        if (horizontal < 0f)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontal > 0f)
        {
            spriteRenderer.flipX = false;
        }
    }
    public void SetSpeed(float newspeed)
    {
        speed = newspeed;
    }
    public float GetSpeed() 
    {
        return speed;
    }
    public void Death()
    {
        loserUI.SetActive(true);
        spriteRenderer.enabled = false;
        bulletPrefab.SetActive(false);
        dead = true;
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
    public void Jump(InputAction.CallbackContext context) 
    {
        if (jumpsRemaining > 0)
        {
            if (context.performed)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
                jumpsRemaining--;
            }
            else if (context.canceled)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
                jumpsRemaining--;
            }
        }
    }
    public void Gravity()
    {
        if (rb.linearVelocity.y < 0f)
        {
            rb.gravityScale = baseGravity * fallSpeedMult;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -maxFallSpeed));
        }
        else
        {
            rb.gravityScale = baseGravity;
        }
    }
}
