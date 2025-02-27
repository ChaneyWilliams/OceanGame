using Unity.VisualScripting;
using UnityEngine;
using static Pathfinding.Util.RetainedGizmos;

public class Player : MonoBehaviour
{
    float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    bool isFacingRight = true;
    public bool canFire = true;
    float timer;
    Bullet bullet;
    int health = 3;
    SpriteFlasher flasher;
    public Color color = Color.white;

    public float timeBetweenShots = 1.5f;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        bullet = bulletPrefab.GetComponent<Bullet>();
        bullet.SetDirection(1f);
        flasher = GetComponent<SpriteFlasher>();
    }

    //see bullet script
    private void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);

        }
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);

        }

        if (Input.GetMouseButtonDown(0) && canFire)
        {
            Shoot();
        }
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer >= timeBetweenShots)
            {
                timer = 0f;
                canFire = true;
            }
        }
        Flip();
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !flasher.isFlashing)
        {
            health -= 1;
            Debug.Log(health);
            StartCoroutine(flasher.Flash(2, color, 4));
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void Shoot()
    {
        Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        canFire = false;
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            if (isFacingRight)
            {
                bullet.SetDirection(1f);
            }
            else { bullet.SetDirection(-1f); }
        }
    }
    public void SetSpeed(float newspeed)
    {
        speed = newspeed;
    }
}
