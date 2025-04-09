using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 camerapos;
    float yValue = 0;
    public float diff = 3;
    public void Awake()
    {
        camerapos = transform.position;
        Camera cam = GetComponent<Camera>();
        cam.orthographicSize = 10;
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
