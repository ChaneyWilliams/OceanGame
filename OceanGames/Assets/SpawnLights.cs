using UnityEngine;

public class SpawnLights : MonoBehaviour
{
    int numOfLights = 3;
    public GameObject light;
    
    void Start()
    {
        for (int i = 0; i < numOfLights; i++) {

            float randX = Random.Range(-transform.localPosition.x, transform.localPosition.x);
            float randY = Random.Range(-transform.localPosition.y, transform.localPosition.y);

            Instantiate(light, new Vector3(randX, randY, transform.localPosition.z), Quaternion.identity);
            Debug.Log("spawned");

        }
    }
}
