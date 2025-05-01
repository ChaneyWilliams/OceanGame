using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 camerapos;
    float yValue = 0;
    public float diff = 3;
    Transform player;
    public void Awake()
    {
        camerapos = transform.position;
        Camera cam = GetComponent<Camera>();
        cam.orthographicSize = 10;
        player = player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.position = player.position;
        
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            if (player.position.y > camerapos.y + diff)
            {
                yValue = player.position.y - diff;
            }
            else if (player.position.y < camerapos.y - diff)
            {
                yValue = player.position.y + diff;
            }
            transform.position = new Vector3(player.position.x, yValue, -15);
        }
    }
}
