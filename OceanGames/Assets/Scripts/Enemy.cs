using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject particles;
    public float health = 10;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Bullet damage = other.GetComponent<Bullet>();
            health -= damage.damage;

        }
        if (health <= 0)
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            Object.Destroy(this.gameObject);
        }
    }
}
