using UnityEngine;

public class SpawnLights : MonoBehaviour
{
    int numOfLights = 3;
    public GameObject lights;
    
    void Start()
    {
        for (int i = 0; i < numOfLights; i++) 
        {
            GameObject newLight = Instantiate(lights, transform.position + new Vector3(Random.Range(-3, 3), Random.Range(-0.5f, 0.5f), 0), Quaternion.identity);
            newLight.GetComponent<Glitter>().SetIntensity(Random.Range(0.1f,1f));
            newLight.GetComponent<Glitter>().SetPerSec(Random.Range(1, 4));
            newLight.GetComponent<Glitter>().SetSpeedRand(Random.Range(1,3));
            newLight.transform.parent = transform;

        }
    }
}
