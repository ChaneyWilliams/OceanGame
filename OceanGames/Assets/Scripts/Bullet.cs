using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    private CircleCollider2D circleCollider;
    public float destoryTimer;
    public float damage;
    float timer;

    public float direction = 1f;
    private bool hit;



    // make the bullets disappear when they hit something or after certain time/distance

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();

    }
    private void FixedUpdate()
    {
        if (hit) { return; }
        float movementSpeed = speed * Time.deltaTime * direction;
        //Debug.Log(movementSpeed);
        transform.Translate(movementSpeed, 0, 0);
        timer += Time.deltaTime;
        
        if (timer > 5f) 
        {
            timer = 0;
            Destroy(this.gameObject);
        }
    }
    public void SetDirection(float newDirection)
    {
        direction = newDirection;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        { 
            Destroy(this.gameObject); 
        }
    }
}
