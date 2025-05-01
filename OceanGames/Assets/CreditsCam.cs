using Unity.VisualScripting;
using UnityEngine;

public class CreditsCam : MonoBehaviour
{
    Transform camPos;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camPos = transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (camPos.position.y == -140)
        {
            rb.linearVelocity = Vector3.zero;
        }
    }
}
