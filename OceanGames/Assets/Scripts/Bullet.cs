using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float destroyTimer;
    public float damage = 5f;
    float timer;
    bool hit = false;
    public float direction = 1f;



    // make the bullets disappear when they hit something or after certain time/distance

    private void FixedUpdate()
    {
        if (hit) { return; }
        float movementSpeed = speed * Time.deltaTime * direction;
        //Debug.Log(movementSpeed);
        transform.Translate(movementSpeed, 0, 0);
        timer += Time.deltaTime;
        
        if (timer > destroyTimer) 
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
