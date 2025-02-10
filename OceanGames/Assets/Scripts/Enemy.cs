using UnityEngine;

public class Enemy : MonoBehaviour
{
    int health = 10;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            health--;
        }
        if (health <= 0)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
