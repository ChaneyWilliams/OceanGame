using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static Pathfinding.Util.RetainedGizmos;

public class Enemy : MonoBehaviour
{

    SpriteFlasher flasher;
    [SerializeField] private GameObject particles;
    public Color color = Color.white;
    public float health = 10;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        flasher = GetComponent<SpriteFlasher>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet") && !flasher.isFlashing)
        {
            Bullet damage = other.GetComponent<Bullet>();
            health -= damage.damage;
            StartCoroutine(flasher.Flash(1, color, 3));

        }
        if (health <= 0)
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            Object.Destroy(this.gameObject);
        }
    }
}
