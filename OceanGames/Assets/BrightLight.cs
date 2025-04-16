using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BrightLight : MonoBehaviour
{
    List<GameObject> lights = new List<GameObject>();
    float time = 0;
    public float speed = 2f;
    public Collider2D player;
    Collider2D collision;

    private void Start()
    {
        collision = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {

        if (lights != null)
        {
            Light2D testLight = lights[0].GetComponent<Light2D>();
            if (collision.IsTouching(player) && testLight.intensity <= 5)
            {
                time += Time.deltaTime * speed;
                GetBright(time);
            }
            else if (!collision.IsTouching(player) && testLight.intensity > 0)
            {
                time -= Time.deltaTime * speed;
                GetBright(time);
            }
        }
    }

    void GetBright(float time)
    {
        foreach (GameObject light in lights)
        {
            Light2D lightIntense = light.GetComponent<Light2D>();
            lightIntense.intensity = time;
        }
    }

    public void AddLight(GameObject light)
    {
        lights.Add(light);
    }
}
