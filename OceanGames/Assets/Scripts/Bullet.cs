using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    private BoxCollider2D boxCollider;
    public float destoryTimer;
    public float damage;
    public float direction = 1f;
    private bool hit;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (hit) { return; }
        float movementSpeed = speed * Time.deltaTime * direction;
        //Debug.Log(movementSpeed);
        transform.Translate( movementSpeed, 0, 0);
    }
    public void SetDirection(float newDirection)
    {
        direction = newDirection;
        //Debug.Log(direction);
    }
}
