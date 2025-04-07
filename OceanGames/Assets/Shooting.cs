using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    Camera cam;
    Vector3 MousePos;

    public Transform bulletTrans;
    public GameObject bullet;
    public bool canFire;
    private float timer;
    public float timeBetween;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = MousePos - transform.position;

        float rotZ = Mathf.Atan2(-rotation.x, rotation.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetween)
            {
                canFire = true;
                timer = 0;
            }
        }
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        if (canFire)
        {
            Instantiate(bullet, bulletTrans.position, Quaternion.identity);
            canFire = false;
        }
        else if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetween)
            {
                canFire = true;
                timer = 0;
            }
        }
    }
}
