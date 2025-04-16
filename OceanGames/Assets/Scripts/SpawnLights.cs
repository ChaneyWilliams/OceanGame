using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpawnLights : MonoBehaviour
{
    int numOfLights = 5;
    public GameObject lights;
    BrightLight brighten;

    void Start()
    {
        brighten = GetComponent<BrightLight>();
        for (int i = 0; i < numOfLights; i++) 
        {
            GameObject newLight = Instantiate(lights, transform.position + new Vector3(Random.Range(-3, 3), Random.Range(-0.5f, 0.5f), 0), Quaternion.identity);
            newLight.transform.parent = transform;
            brighten.AddLight(newLight);

        }
    }
}
