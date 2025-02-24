using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 camerapos;
    float yValue = 0;

    public void Awake()
    {
        camerapos = this.transform.position;
    }

    private void Update()
    {
        if (player != null)
        {
            if (player.position.y > camerapos.y + 5)
            {
                yValue = player.position.y - 5f;
            }
            else if (player.position.y < camerapos.y - 5)
            {
                yValue = player.position.y + 5f;
            }
            this.transform.position = new Vector3(camerapos.x + player.position.x, yValue, -10);
        }
    }
}
