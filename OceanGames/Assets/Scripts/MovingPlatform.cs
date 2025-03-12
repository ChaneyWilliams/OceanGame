using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 5f;
    bool running;
    public Transform[] destinations;
    public Queue<Transform> queue = new Queue<Transform>();

    private void Start()
    {
        for (int i = 0; i < destinations.Length; i++)
        {
            queue.Enqueue(destinations[i]);
        }
        
    }

    private void FixedUpdate()
    {
        if (!running)
        {
            StartCoroutine(MoveTo());
        }
    }

    IEnumerator MoveTo()
    {
        running = true;
        Transform currentTarget = queue.Dequeue();
        queue.Enqueue(currentTarget);
        while (Vector3.Distance(currentTarget.position, transform.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, Time.deltaTime * speed);
            yield return null;
        }
        running = false;
        yield return null;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
