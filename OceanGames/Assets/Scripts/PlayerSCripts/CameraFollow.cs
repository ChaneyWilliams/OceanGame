using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 camerapos;
    float yValue = 0;

    public void Awake()
    {
        camerapos = transform.position;
        Camera cam = GetComponent<Camera>();
        cam.orthographicSize = 9;
        transform.position = player.position;
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            if (player.position.y > camerapos.y + 4)
            {
                yValue = player.position.y - 4f;
            }
            else if (player.position.y < camerapos.y - 4)
            {
                yValue = player.position.y + 4f;
            }
            transform.position = new Vector3(camerapos.x + player.position.x, yValue, -15);
        }
    }
}
