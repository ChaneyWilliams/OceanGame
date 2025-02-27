using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class MovingPlatform : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float speed = 5f;
    bool running;
    Queue<Transform> queue = new Queue<Transform>();


    private void Start()
    {
        queue.Enqueue(start);
        queue.Enqueue(end);
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
}
