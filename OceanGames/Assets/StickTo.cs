using UnityEngine;

public class StickTo : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = GetComponentInParent<MovingPlatform>().speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform, true);
            float playerspeed = collision.gameObject.GetComponent<Player>().speed;
            Debug.Log(playerspeed);
            collision.gameObject.GetComponent<Player>().SetSpeed(playerspeed * speed);
            Debug.Log(playerspeed + speed);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            collision.gameObject.transform.SetParent(null, true);
            float playerspeed = collision.gameObject.GetComponent<Player>().speed;
            Debug.Log(playerspeed);
            collision.gameObject.GetComponent<Player>().SetSpeed(playerspeed / speed);
            Debug.Log(playerspeed - speed);
        }
    }
}
