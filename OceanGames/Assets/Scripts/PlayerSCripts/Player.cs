using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Pathfinding.Util.RetainedGizmos;

public class Player : MonoBehaviour
{
    float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    SpriteFlasher flasher;
    public Color color = Color.white;
    

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
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);

        }
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);

        }

        if(health.health <= 0)
        {
            Death();
        }
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
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
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
    public void Death()
    {
        loserUI.SetActive(true);
        spriteRenderer.enabled = false;
        bulletPrefab.SetActive(false);
        dead = true;
    }
}
