using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BrightLight : MonoBehaviour
{
    List<GameObject> lights = new List<GameObject>();
    float time = 0;
    public float speed = 2f;
    Collider2D player;
    Collider2D collision;
    [SerializeField] AudioClip clip;
    AudioSource source;

    private void Start()
    {
        collision = GetComponent<BoxCollider2D>();
        source = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            source.pitch = Random.Range(.75f, 1.5f);
            source.PlayOneShot(clip);
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
