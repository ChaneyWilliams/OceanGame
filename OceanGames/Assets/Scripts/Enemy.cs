using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static Pathfinding.Util.RetainedGizmos;

public class Enemy : MonoBehaviour
{

    SpriteFlasher flasher;
    [SerializeField] private GameObject particles;
    public Color color = Color.red;
    public float health = 10;

    private void Awake()
    {
        flasher = GetComponent<SpriteFlasher>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Bullet damage = other.GetComponent<Bullet>();
            health -= damage.damage;
            StartCoroutine(flasher.Flash(2, color, 4));

        }
        if (health <= 0)
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            Object.Destroy(this.gameObject);
        }
    }
}
